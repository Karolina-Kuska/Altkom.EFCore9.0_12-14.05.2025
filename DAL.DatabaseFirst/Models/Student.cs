using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Student
{
    public int Id { get; set; }

    public int IndexNumber { get; set; }

    public virtual Person IdNavigation { get; set; } = null!;
}
