using System.ComponentModel.DataAnnotations;

namespace MiWebAPI.Entidades
{
    public class Usuarios
    {
        [Key]
        public int Identificador { get; set; }

        public required string Usuario { get; set; }

        public required string Pass { get; set; }

        public required DateTime Fecha_Creacion { get; set; }
    }
}
