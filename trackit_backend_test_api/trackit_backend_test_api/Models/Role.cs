using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime RoleCreatedAt { get; set; }

    public DateTime RoleEditedAt { get; set; }

    public bool RoleStatus { get; set; }

    public virtual ICollection<ProjectDetail> ProjectDetails { get; } = new List<ProjectDetail>();

    public virtual ICollection<TeamsDetail> TeamsDetails { get; } = new List<TeamsDetail>();

    public virtual ICollection<UserDetail> UserDetails { get; } = new List<UserDetail>();
}
