using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Image { get; set; } = null!;

    public bool AcStatus { get; set; }
}
