using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIA_BackEnd.Entities;

namespace PIA_BackEnd.Controllers
{
    [ApiController]
    [Route("/participantes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Administrador")]
    public class ParticipantController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<ParticipantController> logger;
        public ParticipantController(ApplicationDbContext context, ILogger<ParticipantController> logger)
        {
            this.dbContext = context;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Participant participant)
        {
            dbContext.Add(participant);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("listado")]
        public async Task<ActionResult<List<Participant>>> Get()
        {
            return await dbContext.Participants.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Participant participant, int id)
        {
            if (participant.Id != id)
            {
                logger.LogError("Error de coincidencia de IDs");
                return BadRequest("El id del participante no coincide con el establecido en la url.");

            }

            dbContext.Update(participant);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Participants.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            dbContext.Remove(new Participant { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
