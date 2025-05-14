using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class SubComponent
{
    public int Id { get; set; }

    public int ComponentId { get; set; }

    public string StatusId { get; set; } = null!;

    public virtual Component Component { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
