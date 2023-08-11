using System;
using System.Collections.Generic;

namespace test_tryCatch.Data.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Direccion { get; set; }

    public string CodigoEmpleado { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Rol { get; set; } = null!;

    public string Status { get; set; } = null!;
}
