using API_JBG.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using API_JBG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_JBG.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly ConexionSQLServer context;
        public UsuariosController(ConexionSQLServer context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return context.Usuarios.ToList();
        }

        [HttpGet("{id:required}", Name = "GetUsuarioPorCedula")]
        public IActionResult GetUsuarioPorCedula(string id)
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();

                if (id is null)
                {
                    usuarios = context.Usuarios.ToList();
                }
                else
                {
                    SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_buscar_usuarios";
                    command.Parameters.AddWithValue("cedula", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuarios usuario = new()
                        {
                            cedula = (string)reader["cedula"],
                            nombre = (string)reader["nombre"],
                            apellido = (string)reader["apellido"],
                            direccion = (string)reader["direccion"]
                        };
                        usuarios.Add(usuario);
                    }
                    connection.Close();
                }

                if (usuarios.Count == 0)
                {
                    return new NotFoundResult();
                }

                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Error");
            }
        }

    }
}
