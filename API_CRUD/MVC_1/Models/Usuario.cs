using System;
using System.Collections.Generic;

namespace MVC_1.Models;

public partial class Usuario
{
    public string Cedula { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }
}
