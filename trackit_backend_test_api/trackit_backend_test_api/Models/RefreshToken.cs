using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class RefreshToken
{
    public int RefreshTokenId { get; set; }

    public int RefreshTokenUid { get; set; }

    public string RefreshToken1 { get; set; } = null!;

    public bool RefreshTokenStatus { get; set; }

    public virtual User RefreshTokenU { get; set; } = null!;
}
