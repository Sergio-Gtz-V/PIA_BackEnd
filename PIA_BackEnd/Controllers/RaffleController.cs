using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIA_BackEnd.Entities;
using AutoMapper;
using PIA_BackEnd.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace PIA_BackEnd.Controllers
{
    [ApiController]
    [Route("/rifas")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Administrador")]
    public class RaffleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<RaffleController> logger;
        private readonly IMapper mapper;
        public RaffleController(ApplicationDbContext context, ILogger<RaffleController> logger, IMapper mapper)
        {
            this.dbContext = context;
            this.logger = logger;
            this.mapper = mapper;   
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
