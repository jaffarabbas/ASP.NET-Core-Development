using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class UserStory
{
    public int UserStoryId { get; set; }

    public string UserStoryName { get; set; } = null!;

    public string? UserStoryDescription { get; set; }

    public DateTime UserStoryCreatedAt { get; set; }

    public DateTime UserStoryEditedAt { get; set; }

    public bool UserStoryStatus { get; set; }

    public virtual ICollection<UserStoryDetail> UserStoryDetails { get; } = new List<UserStoryDetail>();
}
