using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public DateTime TeamCreatedAt { get; set; }

    public DateTime TeamEditedAt { get; set; }

    public bool TeamStatus { get; set; }

    public virtual ICollection<ProjectAssigned> ProjectAssigneds { get; } = new List<ProjectAssigned>();

    public virtual ICollection<TeamAssigned> TeamAssigneds { get; } = new List<TeamAssigned>();

    public virtual ICollection<TeamsDetail> TeamsDetails { get; } = new List<TeamsDetail>();
}
