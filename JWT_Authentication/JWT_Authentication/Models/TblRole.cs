using System;
using System.Collections.Generic;

namespace JWT_Authentication.Models;

public partial class TblRole
{
    public string Roleid { get; set; } = null!;

    public string? Name { get; set; }
}
