using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Comment
{
    public int Cid { get; set; }

    public int CommentsId { get; set; }

    public int TaskId { get; set; }

    public int Uid { get; set; }

    public DateTime CommentsCreatedAt { get; set; }

    public DateTime CommentsEditedAt { get; set; }

    public bool CommentsStatus { get; set; }

    public virtual CommentsDetail Comments { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;

    public virtual User UidNavigation { get; set; } = null!;
}
