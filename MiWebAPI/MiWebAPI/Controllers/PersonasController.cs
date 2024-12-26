using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebAPI.Entidades;

namespace MiWebAPI.Controllers
{
    [Route("api/personas")]
    public class PersonasController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        [HttpGet]
        public async Task<List<Personas>> Get()
        {
            return await context.Personas.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerPersonaPorId")]
        public async Task<ActionResult<Personas>> Get(int id)
        {
            var persona = await context.Personas.FirstOrDefaultAsync(x => x.Identificador == id);

            if (persona is null)
            {
                return NotFound();
            }

            return persona;
        }

        [HttpPost]
        public async Task<CreatedAtRouteResult> Post([FromBody] Personas persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerPersonasPorId", new { id = persona.Identificador }, persona);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Personas persona)
        {
            var existePersona = await context.Personas.AnyAsync(x => x.Identificador == id);

            if (!existePersona)
            {
                return NotFound();
            }

            persona.Identificador = id;
            context.Update(persona);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasBorradas = await context.Personas.Where(x => x.Identificador == id).ExecuteDeleteAsync();

            if (filasBorradas == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
