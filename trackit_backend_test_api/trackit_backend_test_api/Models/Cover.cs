using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Cover
{
    public int CoverId { get; set; }

    public string CoverData { get; set; } = null!;

    public DateTime CoverCreatedAt { get; set; }

    public DateTime CoverEditedAt { get; set; }

    public bool CoverStatus { get; set; }

    public virtual ICollection<ProjectDetail> ProjectDetails { get; } = new List<ProjectDetail>();

    public virtual ICollection<TeamsDetail> TeamsDetails { get; } = new List<TeamsDetail>();
}
