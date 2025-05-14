using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Animal
{
    public int Key { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;
}
