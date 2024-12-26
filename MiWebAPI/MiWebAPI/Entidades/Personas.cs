using System.ComponentModel.DataAnnotations;

namespace MiWebAPI.Entidades
{
    public class Personas
    {
        [Key]
        public int Identificador { get; set; }

        public required string Nombres { get; set; }

        public required string Apellidos { get; set; }

        public required string Numero_Identificacion { get; set; }

        public required string Email { get; set; }

        public required string Tipo_Identificacion { get; set; }

        public required DateTime Fecha_Creacion { get; set; }
    }
}
