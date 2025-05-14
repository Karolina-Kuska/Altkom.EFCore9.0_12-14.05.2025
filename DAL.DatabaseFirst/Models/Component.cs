using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Component
{
    public int Id { get; set; }

    public virtual ICollection<SubComponent> SubComponents { get; set; } = new List<SubComponent>();
}
