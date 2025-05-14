using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Driver
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
