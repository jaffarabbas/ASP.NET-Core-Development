using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class TeamAssigned
{
    public int TeamAssignedId { get; set; }

    public int TeamId { get; set; }

    public int UserId { get; set; }

    public DateTime TeamAssignedCreatedAt { get; set; }

    public DateTime TeamAssignedEditedAt { get; set; }

    public bool TeamAssignedStatus { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
