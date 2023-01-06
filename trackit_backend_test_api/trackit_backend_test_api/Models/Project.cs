using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateTime ProjectCreatedAt { get; set; }

    public DateTime ProjectEditedAt { get; set; }

    public bool ProjectStatus { get; set; }

    public virtual ICollection<ProjectAssigned> ProjectAssigneds { get; } = new List<ProjectAssigned>();

    public virtual ICollection<ProjectDetail> ProjectDetails { get; } = new List<ProjectDetail>();

    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
