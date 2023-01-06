using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Link
{
    public int LinkId { get; set; }

    public int AttachmentsId { get; set; }

    public string LinkLink { get; set; } = null!;

    public DateTime LinkCreatedAt { get; set; }

    public DateTime LinkEditedAt { get; set; }

    public bool LinkStatus { get; set; }

    public virtual Attachment Attachments { get; set; } = null!;
}
