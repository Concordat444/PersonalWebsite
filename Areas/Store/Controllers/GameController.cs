using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.ViewModels;

namespace PersonalWebsite.Areas.Store.Controllers
{
    [Area("Store")]
    public class GameController(StoreContext context) : Controller
    {
        private readonly StoreContext Context = context;
        private IEnumerable<Category> Categories => Context.Categories;
        private List<Publisher> Publishers => Context.Publisher.ToList();
        public int PageSize = 10;

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

            if(ModelState.IsValid)
            {
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
    }
}
