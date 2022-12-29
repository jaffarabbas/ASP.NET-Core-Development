using System;
using System.Collections.Generic;

namespace JWT_Authentication.Models;

public partial class TblDesignation
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }
}
