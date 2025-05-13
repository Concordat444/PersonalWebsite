using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Infrastructure;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.ViewModels;

namespace PersonalWebsite.Areas.Store.Controllers
{
    [Area("Store")]
    public class GameController(StoreContext context) : Controller
    {
        private readonly StoreContext Context = context;
        private IEnumerable<Category> Categories => Context.Categories;
        private List<Publisher> Publishers => [.. Context.Publisher];
        public int PageSize = 10;
        int ProtectedEntries { get; } = 13;

        public IActionResult Index(int listPage)
        {
            return View(new GameListViewModel()
            {
                Games = Context.Games.Include(g => g.Category)
                .OrderBy(g => g.GameId)
                .Skip((listPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new()
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = Context.Games.Count()
                }
            });
        }

        public async Task<IActionResult> Details(long id)
        {
            Game game = await Context.Games.Include(g => g.Category).Include(g => g.Publishers).FirstOrDefaultAsync(g => g.GameId == id) ?? new() { Name = string.Empty };
            return View("GameEditor", GameViewModelFactory.Details(game));
        }

        public async Task<IActionResult> Edit(long id)
        {
            Game game = await Context.Games.Include(g => g.Category).Include(g => g.Publishers).FirstOrDefaultAsync(g => g.GameId == id) ?? new() { Name = string.Empty };
            return View("GameEditor", GameViewModelFactory.Edit(game, Categories, Publishers));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game game, List<long> PublisherIds)
        {

            if (ModelState.IsValid)
            {
                if (game.GameId <= ProtectedEntries)
                {
                    string message =
                        $"The original {ProtectedEntries} entries are for demonstration purposes and should not be modified. To test CRUD features, please create a new entry to work on.";
                    return View("Index", new GameListViewModel()
                    {
                        Games = Context.Games.Include(g => g.Category)
                            .OrderBy(g => g.GameId)
                            .Take(PageSize),
                        PagingInfo = new()
                        {
                            CurrentPage = 1,
                            ItemsPerPage = PageSize,
                            TotalItems = Context.Games.Count()
                        },
                        Message = message
                    });
                }


                Game? Game = await Context.Games.Include(x => x.Publishers).FirstOrDefaultAsync(x => x.GameId == game.GameId);
                if(Game == null)
                {
                    return NotFound();
                }
                List<Publisher> publishers = await Context.Publisher.Where(p => PublisherIds.Contains(p.PublisherId)).ToListAsync();

                Game.Name = game.Name;
                Game.ImageLink = game.ImageLink;
                Game.GameDescription = game.GameDescription;
                Game.CategoryId = game.CategoryId;
                Game.Category = default;

                foreach (Publisher publisher in Game.Publishers!.ToList())
                {
                    if(!publishers.Contains(publisher))
                    {
                        Game.Publishers!.Remove(publisher);
                    }
                }
                foreach (Publisher publisher in publishers)
                {
                    if (!Game.Publishers!.Contains(publisher))
                    {
                        Game.Publishers!.Add(publisher);
                    }
                }
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("GameEditor", GameViewModelFactory.Edit(game, Categories, Publishers));
        }

        public IActionResult Create()
        {
            return View("GameEditor", GameViewModelFactory.Create(Categories, Publishers));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game, List<long> PublisherIds)
        {
            Game Game = game;
            Game.Publishers = await Context.Publisher.Where(x => PublisherIds.Contains(x.PublisherId)).ToListAsync();
            if(ModelState.IsValid)
            {
                Game.GameId = default;
                Game.Category = default;
                Context.Games.Add(Game);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("GameEditor", GameViewModelFactory.Create(Categories, Publishers));
        }

        public async Task<IActionResult> Delete(long id)
        {
            Game? Game = await Context.Games.FirstOrDefaultAsync(x => x.GameId == id) ?? new() { Name = string.Empty };
            return View("GameEditor", GameViewModelFactory.Delete(Game, Categories));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Game game)
        {
            if (game.GameId <= ProtectedEntries)
            {
                string message =
                    $"The original {ProtectedEntries} entries are for demonstration purposes and should not be modified. To test CRUD features, please create a new entry to work on.";
                return View("Index", new GameListViewModel()
                {
                    Games = Context.Games.Include(g => g.Category)
                        .OrderBy(g => g.GameId)
                        .Take(PageSize),
                    PagingInfo = new()
                    {
                        CurrentPage = 1,
                        ItemsPerPage = PageSize,
                        TotalItems = Context.Games.Count()
                    },
                    Message = message
                });
            }
            Context.Games.Remove(game);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
