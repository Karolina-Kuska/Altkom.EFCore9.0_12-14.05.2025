using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }
}
