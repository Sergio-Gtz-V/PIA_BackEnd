using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIA_BackEnd.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PIA_BackEnd.Controllers
{
    [ApiController]
    [Route("/premios")]
    public class PrizesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<PrizesController> logger;
        private readonly IMapper mapper;
        public PrizesController(ApplicationDbContext context, ILogger<PrizesController> logger, IMapper mapper)
        {
            this.dbContext = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Prizes prize)
        {
            dbContext.Add(prize);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("listado")]
        public async Task<ActionResult<List<Prizes>>> Get()
        {
            return await dbContext.Prizes.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Prizes prize, int id)
        {
            if (prize.Id != id)
            {
                logger.LogError("Error de coincidencia de IDs");
                return BadRequest("El id del premio no coincide con el establecido en la url.");

            }

            dbContext.Update(prize);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Prizes.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            dbContext.Remove(new Prizes { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
