using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class RefreshToken
{
    public int Rid { get; set; }

    public int Ruid { get; set; }

    public string RefreshToken1 { get; set; } = null!;

    public bool Rstatus { get; set; }

    public DateTime Rcreatedat { get; set; }

    public virtual User Ru { get; set; } = null!;
}
