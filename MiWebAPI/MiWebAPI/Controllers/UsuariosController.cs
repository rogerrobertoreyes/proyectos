using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebAPI.Entidades;

namespace MiWebAPI.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UsuariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        [HttpGet]
        public async Task<List<Usuarios>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerUsuarioPorId")]
        public async Task<ActionResult<Usuarios>> Get(int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Identificador == id);

            if (usuario is null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<CreatedAtRouteResult> Post([FromBody] Usuarios usuario)
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerUsuarioPorId", new { id = usuario.Identificador }, usuario);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuarios usuario)
        {
            var existeUsuario = await context.Usuarios.AnyAsync(x => x.Identificador == id);

            if (!existeUsuario)
            {
                return NotFound();
            }

            usuario.Identificador = id;
            context.Update(usuario);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasBorradas = await context.Usuarios.Where(x => x.Identificador == id).ExecuteDeleteAsync();

            if (filasBorradas == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
