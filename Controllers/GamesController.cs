using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PersonalWebsite.Controllers
{
    [Route("api/[controller]")]
    public class GamesController(StoreContext context) : ControllerBase
    {
        private StoreContext context { get; set; } = context;
        private IEnumerable<Category> categories = context.Categories;
        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            IEnumerable<Game> games = context.Games.Include(g => g.Publishers);
            foreach (Game game in games)
            {
                foreach (Publisher publisher in game.Publishers!)
                {
                    publisher.Games = null;
                }
            }
            return games;
        }

        [HttpGet("simple")]
        public async Task<IActionResult> GetSimpleGames()
        {
            List<Game> games = await context.Games.Include(g => g.Publishers).Include(g => g.Products).Include(g => g.Category).ToListAsync();
            List<SimpleGameJSON> simpleGames = games.ConvertAll(new Converter<Game, SimpleGameJSON>(ConversionClasses.GameToSimpleGameJSON));
            return Ok(simpleGames);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(long id)
        {
            Game? game = await context.Games.Include(g => g.Publishers).Include(g => g.Products).Include(g => g.Category).FirstOrDefaultAsync(g => g.GameId == id);
            if (game == null)
            {
                return NotFound();
            }
            SimpleGameJSON gameJSON = ConversionClasses.GameToSimpleGameJSON(game) ?? new SimpleGameJSON();
            return Ok(gameJSON);
        }

        [HttpPost]
        public async Task<IActionResult> SaveGame([FromBody] GameBindingTarget target)
        {
            if (ModelState.IsValid)
            {
                Category _category = categories.FirstOrDefault((c => c.CategoryID == target.CategoryId), categories.First(c => c.Name == "Other"));
                long _categoryId = _category.CategoryID;
                Game game = new()
                {
                    Name = target.Name,
                    GameDescription = target.GameDescription,
                    CategoryId = _categoryId,
                    Category = _category,
                    ImageLink = target.ImageLink,
                    PublicationYear = target.PublicationYear,
                    Products = target.ProductIds.Count == 0 ? [] : context.Products.Where(p => target.ProductIds.Contains(p.ProductId)),
                    Publishers = target.PublisherIds.Count == 0 ? [] : context.Publisher.Where(p => target.PublisherIds.Contains(p.PublisherId)).ToList()
                };
                await context.Games.AddAsync(game);
                await context.SaveChangesAsync();
                return Ok(ConversionClasses.GameToSimpleGameJSON(game));
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGame([FromBody] Game game)
        {
            
            if(context.Games.FirstOrDefaultAsync(g => g.GameId == game.GameId) == null)
            {
                return NotFound();
            }
            context.Update(game);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(long id)
        {
            context.Games.Remove(new Game()
            {
                GameId = id,
                Name = string.Empty
            });
            await context.SaveChangesAsync();
            return Ok();
        }

        //[HttpPatch]
        //public async Task<IActionResult> ModifyGame(Game game)
        //{
        //    if(context.Games.FirstOrDefault(g =>  g.GameId == game.GameId) == null)
        //    {

        //    }
        //}
    }
}
