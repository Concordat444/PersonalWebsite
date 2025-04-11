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
        public List<SimpleGameJSON> GetSimpleGames()
        {
            List<Game> games = context.Games.Include(g => g.Publishers).Include(g => g.Products).Include(g => g.Category).ToList();
            List<SimpleGameJSON> simpleGames = games.ConvertAll(new Converter<Game, SimpleGameJSON>(SimpleGameJSON.GameToSimpleGameJSON));
            return simpleGames;
        }
    }
}
