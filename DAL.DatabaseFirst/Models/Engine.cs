using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Engine
{
    public int Id { get; set; }

    public int Power { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
