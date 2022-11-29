﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIA_BackEnd.Entities;

namespace PIA_BackEnd.Controllers
{
    [ApiController]
    [Route("/rifas")]
    public class RaffleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<RaffleController> logger;
        public RaffleController(ApplicationDbContext context, ILogger<RaffleController> logger)
        {
            this.dbContext = context;
            this.logger = logger;
        }

        [HttpPost]
        [ResponseCache(Duration = 10)]
        public async Task<ActionResult> Post(Raffle raffle)
        {
            dbContext.Add(raffle);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("listado")]
        public async Task<ActionResult<List<Raffle>>> Get()
        {
            return await dbContext.Rifas.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Raffle raffle, int id)
        {
            if (raffle.Id != id)
            {
                logger.LogError("Error de coincidencia de IDs");
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
