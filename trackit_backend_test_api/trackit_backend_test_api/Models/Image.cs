using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public int AttachmentsId { get; set; }

    public string ImageLink { get; set; } = null!;

    public DateTime ImageCreatedAt { get; set; }

    public DateTime ImageEditedAt { get; set; }

    public bool ImageStatus { get; set; }

    public virtual Attachment Attachments { get; set; } = null!;
}
