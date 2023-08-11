using System;
using System.Collections.Generic;

namespace test_tryCatch.Data.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public long IdUser { get; set; }

    public string? Direccion { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public string Descripcion { get; set; } = null!;

    public string ServiceType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Status { get; set; } = null!;

    public string? Priority { get; set; }

    public DateOnly? ServiceDate { get; set; }
}
