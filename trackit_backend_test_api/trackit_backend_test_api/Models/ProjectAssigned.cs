using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class ProjectAssigned
{
    public int ProjectAssignedId { get; set; }

    public int ProjectId { get; set; }

    public int TeamId { get; set; }

    public DateTime ProjectAssignedCreatedAt { get; set; }

    public DateTime ProjectAssignedEditedAt { get; set; }

    public bool ProjectAssignedStatus { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
