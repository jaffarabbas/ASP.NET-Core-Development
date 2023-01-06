using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class TaskDetail
{
    public int TaskDetailsId { get; set; }

    public int TaskId { get; set; }

    public int TaskDetailsTypeId { get; set; }

    public decimal TaskDetailsPriority { get; set; }

    public DateTime? TaskDetailsStartDate { get; set; }

    public DateTime? TaskDetailsEndDate { get; set; }

    public bool TaskDetailsMainTask { get; set; }

    public bool TaskDetailsSubTask { get; set; }

    public DateTime TaskDetailsCreatedAt { get; set; }

    public DateTime TaskDetailsEditedAt { get; set; }

    public bool TaskDetailsStatus { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual Type TaskDetailsType { get; set; } = null!;
}
