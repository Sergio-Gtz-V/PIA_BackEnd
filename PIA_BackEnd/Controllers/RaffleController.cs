using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIA_BackEnd.Entities;

namespace PIA_BackEnd.Controllers
{
    [ApiController]
    [Route("/rifas")]
    public class RaffleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public RaffleController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Raffle raffle)
        {
            dbContext.Add(raffle);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Raffle>>> Get()
        {
            return await dbContext.Rifas.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Raffle raffle, int id)
        {
            if (raffle.Id != id)
            {
                return BadRequest("El id de la rifa no coincide con el establecido en la url.");
            }

            dbContext.Update(raffle);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete( int id)
        {
            var exists = await dbContext.Rifas.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            dbContext.Remove(new Raffle { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
