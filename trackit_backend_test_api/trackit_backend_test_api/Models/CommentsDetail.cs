using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class CommentsDetail
{
    public int CommentsId { get; set; }

    public string CommentsDetailsComment { get; set; } = null!;

    public DateTime CommentsDetailsCreatedAt { get; set; }

    public DateTime CommentsDetailsEditedAt { get; set; }

    public bool CommentsDetailsStatus { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
}
