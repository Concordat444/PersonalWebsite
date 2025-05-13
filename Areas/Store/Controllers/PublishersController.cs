using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models.StoreModels;
using PersonalWebsite.Models.StoreModels.APIOutputs;

namespace PersonalWebsite.Areas.Store.Controllers
{
    [Route("api/[Controller]")]
    public class PublishersController(StoreContext context) : ControllerBase
    {
        private StoreContext context { get; set; } = context;

        [HttpGet]
        public IEnumerable<Publisher> GetPublishers()
        {
            return  context.Publisher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher(long id)
        {
            Publisher? publisher = await context.Publisher.Include(g => g.Games).Where(p => p.PublisherId == id).FirstOrDefaultAsync();
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher.ToPublisherOutput());
        }

        [HttpPost]
        public async Task<IActionResult> SavePublisher([FromBody] PublisherBindingTarget target)
        {
            if(ModelState.IsValid)
            {
                await context.Publisher.AddAsync(
                    new()
                    {
                        PublisherName = target.PublisherName
                    });
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePublisher([FromBody] PublisherBindingTarget target)
        {
            if (target.Id <= 16)
            {
                return StatusCode(405, new { message = "Entries 1-16 are required for demonstration purposes and may not be altered." });
            }
            if (ModelState.IsValid)
            {
                List<Game> games = target.GameIds == null
                    ? []
                    : await context.Games.Where(g => target.GameIds.Contains(g.GameId)).ToListAsync();
                Publisher publisher = new()
                {
                    PublisherId = (long)target.Id!,
                    PublisherName = target.PublisherName,
                    Games = games
                };
                context.Update(publisher);
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePublisher(long id)
        {
            if (id <= 16)
            {
                return StatusCode(405, new { message = "Entries 1-16 are required for demonstration purposes and may not be altered." });
            }
            context.Publisher.Remove(new()
            {
                PublisherId = id,
                PublisherName = string.Empty
            });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
