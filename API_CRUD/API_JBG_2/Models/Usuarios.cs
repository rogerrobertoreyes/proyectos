using System.ComponentModel.DataAnnotations;

namespace API_JBG_2.Models
{
    public class Usuarios
    {
        [Key]
        public required string cedula { get; set; }

        public required string nombre { get; set; }

        public required string apellido { get; set; }

        public required string direccion { get; set; }

        //public required String[] detalle { get; set; }
    }
}
