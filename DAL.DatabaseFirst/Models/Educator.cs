using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Educator
{
    public int Id { get; set; }

    public string Specialization { get; set; } = null!;

    public float Salary { get; set; }

    public virtual Person IdNavigation { get; set; } = null!;
}
