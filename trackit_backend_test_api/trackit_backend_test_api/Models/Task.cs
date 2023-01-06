using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public DateTime TaskCreatedAt { get; set; }

    public DateTime TaskEditedAt { get; set; }

    public bool TaskStatus { get; set; }

    public virtual ICollection<Attachment> Attachments { get; } = new List<Attachment>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<TaskDetail> TaskDetails { get; } = new List<TaskDetail>();
}
