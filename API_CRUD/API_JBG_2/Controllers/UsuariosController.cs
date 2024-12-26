using API_JBG_2.Contexts;
using API_JBG_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations;

namespace API_JBG_2.Controllers
{
    [Route("api/usuarios")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        public readonly SQLServerConnection context;
        public List<Usuarios> usuarios = new();
        public List<Usuarios> usuario = new();

        public UsuariosController(SQLServerConnection context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            usuarios = new();
            usuarios = context.Usuarios.ToList();

            /*while (true)
            {

            }*/
            return context.Usuarios.ToList();
        }

        [HttpGet("{id:required}", Name = "GetUsuariosPorCedula")]
        public IActionResult GetUsuariosPorCedula(string id)
        {
            try
            {
                usuarios = new();

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
                            direccion = (string)reader["direccion"]//,
                            //detalle = new[] { (string)reader["nombre"], (string)reader["apellido"], (string)reader["direccion"] }
                        };

                        usuarios.Add(usuario);
                    }
                    connection.Close();

                }

                if (usuarios.Count == 0)
                {
                    return new NotFoundResult();
                }

                foreach (var usuario in usuarios)
                {
                    Console.WriteLine(usuario.nombre);
                }
                for (var i = 0; i < usuarios.Count; i++)
                {
                    Console.WriteLine(usuarios[i].nombre);
                }
                usuarios.ForEach((usuario) =>
                {
                    Console.WriteLine(usuario.nombre);
                });

                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Error en metodo: GetUsuariosPorCedula");
            }
        }

    }
 }
