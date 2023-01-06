using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class ProjectDetail
{
    public int ProjectDetailsId { get; set; }

    public int ProjectId { get; set; }

    public string? ProjectDetailsDescription { get; set; }

    public int? ProjectDetailsRoleId { get; set; }

    public int? ProjectDetailsProfileId { get; set; }

    public int? ProjectDetailsCoverId { get; set; }

    public DateTime ProjectDetailsCreatedAt { get; set; }

    public DateTime ProjectDetailsEditedAt { get; set; }

    public bool ProjectDetailsStatus { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Cover? ProjectDetailsCover { get; set; }

    public virtual Profile? ProjectDetailsProfile { get; set; }

    public virtual Role? ProjectDetailsRole { get; set; }
}
