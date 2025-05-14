using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public int? NumberOfWorkers { get; set; }

    public string? OwnerName { get; set; }

    public string? CoOwnerName { get; set; }
}
