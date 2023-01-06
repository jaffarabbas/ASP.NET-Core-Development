using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Attachment
{
    public int AttachmentsId { get; set; }

    public int AttachmentsTaskId { get; set; }

    public DateTime AttachmentsCreatedAt { get; set; }

    public DateTime AttachmentsEditedAt { get; set; }

    public bool AttachmentsStatus { get; set; }

    public virtual Task AttachmentsTask { get; set; } = null!;

    public virtual ICollection<Image> Images { get; } = new List<Image>();

    public virtual ICollection<Link> Links { get; } = new List<Link>();
}
