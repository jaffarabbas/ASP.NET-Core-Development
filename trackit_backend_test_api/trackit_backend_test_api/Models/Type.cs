using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Type
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public DateTime TypeCreatedAt { get; set; }

    public DateTime TypeEditedAt { get; set; }

    public bool TypeStatus { get; set; }

    public virtual ICollection<TaskDetail> TaskDetails { get; } = new List<TaskDetail>();

    public virtual ICollection<UserStoryDetail> UserStoryDetails { get; } = new List<UserStoryDetail>();
}
