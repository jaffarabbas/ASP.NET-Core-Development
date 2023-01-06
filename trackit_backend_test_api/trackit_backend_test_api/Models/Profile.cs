using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public string ProfileData { get; set; } = null!;

    public DateTime ProfileCreatedAt { get; set; }

    public DateTime ProfileEditedAt { get; set; }

    public bool ProfileStatus { get; set; }

    public virtual ICollection<ProjectDetail> ProjectDetails { get; } = new List<ProjectDetail>();

    public virtual ICollection<TeamsDetail> TeamsDetails { get; } = new List<TeamsDetail>();
}
