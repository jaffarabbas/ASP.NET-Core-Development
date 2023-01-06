using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class ReportsDetail
{
    public int ReportDetailsId { get; set; }

    public string ReportData { get; set; } = null!;

    public DateTime ReportDetailsCreatedAt { get; set; }

    public DateTime ReportDetailsEditedAt { get; set; }

    public bool ReportDetailsStatus { get; set; }

    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
