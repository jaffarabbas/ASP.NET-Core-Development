using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class TeamsDetail
{
    public int TeamDetailsId { get; set; }

    public int TeamId { get; set; }

    public string? TeamDetailsDescription { get; set; }

    public int? TeamDetailsRoleId { get; set; }

    public int? TeamDetailsProfileId { get; set; }

    public int? TeamDetailsCoverId { get; set; }

    public DateTime TeamDetailsCreatedAt { get; set; }

    public DateTime TeamDetailsEditedAt { get; set; }

    public bool TeamDetailsStatus { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual Cover? TeamDetailsCover { get; set; }

    public virtual Profile? TeamDetailsProfile { get; set; }

    public virtual Role? TeamDetailsRole { get; set; }
}
