using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Car
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public int? RegistrationId { get; set; }

    public int? EngineId { get; set; }

    public virtual Engine? Engine { get; set; }

    public virtual Registration? Registration { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
