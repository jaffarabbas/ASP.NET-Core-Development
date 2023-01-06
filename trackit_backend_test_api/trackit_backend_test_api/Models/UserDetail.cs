using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class UserDetail
{
    public int UserDetailsId { get; set; }

    public int Uid { get; set; }

    public string? UserDetailsUsername { get; set; }

    public string? UserDetailsFirstname { get; set; }

    public string? UserDetailsLastname { get; set; }

    public int? UserDetailsRoleId { get; set; }

    public int? UserDetailsAuthId { get; set; }

    public DateTime UserDetailsCreatedAt { get; set; }

    public DateTime UserDetailsEditedAt { get; set; }

    public bool UserDetailsStatus { get; set; }

    public virtual User UidNavigation { get; set; } = null!;

    public virtual Auth? UserDetailsAuth { get; set; }

    public virtual Role? UserDetailsRole { get; set; }
}
