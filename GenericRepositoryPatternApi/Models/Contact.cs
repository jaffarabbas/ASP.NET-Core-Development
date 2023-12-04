using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class Contact
{
    public int Conid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime Stamp { get; set; }

    public bool CoStatus { get; set; }
}
