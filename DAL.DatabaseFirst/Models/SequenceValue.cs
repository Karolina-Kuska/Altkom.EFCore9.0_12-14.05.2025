using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class SequenceValue
{
    public int Id { get; set; }

    public int Value { get; set; }

    public string Name { get; set; } = null!;
}
