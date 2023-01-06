using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Auth
{
    public int AuthId { get; set; }

    public string AuthType { get; set; } = null!;

    public int AuthCreatedBy { get; set; }

    public int AuthEditedBy { get; set; }

    public DateTime AuthCreatedAt { get; set; }

    public DateTime AuthEditedAt { get; set; }

    public bool AuthStatus { get; set; }

    public virtual ICollection<UserDetail> UserDetails { get; } = new List<UserDetail>();
}
