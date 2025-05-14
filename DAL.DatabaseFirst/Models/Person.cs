using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public decimal Pesel { get; set; }

    public DateTime CreatedAt { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public virtual Educator? Educator { get; set; }

    public virtual Student? Student { get; set; }
}
