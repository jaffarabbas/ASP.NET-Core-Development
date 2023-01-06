using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class User
{
    public int Uid { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public DateTime UserCreatedAt { get; set; }

    public DateTime UserEditedAt { get; set; }

    public bool UserStatus { get; set; }

    public string UserUuid { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; } = new List<RefreshToken>();

    public virtual ICollection<TeamAssigned> TeamAssigneds { get; } = new List<TeamAssigned>();

    public virtual ICollection<UserDetail> UserDetails { get; } = new List<UserDetail>();

    public virtual ICollection<UserPoint> UserPoints { get; } = new List<UserPoint>();
}
