using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Status
{
    public string Id { get; set; } = null!;

    public virtual ICollection<SubComponent> SubComponents { get; set; } = new List<SubComponent>();
}
