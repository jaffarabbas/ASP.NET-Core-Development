using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public int ReportDetailsId { get; set; }

    public int ReportProjectId { get; set; }

    public DateTime ReportCreatedAt { get; set; }

    public DateTime ReportEditedAt { get; set; }

    public bool ReportStatus { get; set; }

    public virtual ReportsDetail ReportDetails { get; set; } = null!;

    public virtual Project ReportProject { get; set; } = null!;
}
