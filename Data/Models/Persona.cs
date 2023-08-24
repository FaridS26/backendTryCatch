using System;
using System.Collections.Generic;

namespace test_tryCatch.Data.Models
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Celular { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Direccion { get; set; }

        public int? CodigoEmpleado { get; set; }

        public string Cedula { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.MinValue;

        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;

        public string Rol { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }
    }
}
