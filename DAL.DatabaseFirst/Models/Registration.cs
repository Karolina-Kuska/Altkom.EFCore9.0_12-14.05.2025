using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Registration
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public virtual Car? Car { get; set; }
}
