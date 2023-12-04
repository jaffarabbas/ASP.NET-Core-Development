using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class User
{
    public int Uid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Acid { get; set; }

    public bool UStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AccountType Ac { get; set; } = null!;

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
}
