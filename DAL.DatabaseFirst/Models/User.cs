using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string? Password { get; set; }
}
