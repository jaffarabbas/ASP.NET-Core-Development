using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class UserStoryDetail
{
    public int UserStoryDetailsId { get; set; }

    public int UserStoryId { get; set; }

    public int UserStoryDetailsTypeId { get; set; }

    public decimal UserStoryDetailsPriority { get; set; }

    public DateTime? UserStoryDetailsStartDate { get; set; }

    public DateTime? UserStoryDetailsEndDate { get; set; }

    public bool UserStoryDetailsMainTask { get; set; }

    public bool UserStoryDetailsSubTask { get; set; }

    public DateTime UserStoryDetailsCreatedAt { get; set; }

    public DateTime UserStoryDetailsEditedAt { get; set; }

    public bool UserStoryDetailsStatus { get; set; }

    public virtual UserStory UserStory { get; set; } = null!;

    public virtual Type UserStoryDetailsType { get; set; } = null!;
}
