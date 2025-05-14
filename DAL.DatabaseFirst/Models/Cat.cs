using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Cat
{
    public int Key { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Color { get; set; } = null!;
}
