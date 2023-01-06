using System;
using System.Collections.Generic;

namespace trackit_backend_test_api.Models;

public partial class UserPoint
{
    public int UserPointsId { get; set; }

    public int Uid { get; set; }

    public int? UserPointsTotal { get; set; }

    public bool UserIsAvaible { get; set; }

    public DateTime UserPointsCreatedAt { get; set; }

    public DateTime UserPointsEditedAt { get; set; }

    public bool UserPointsStatus { get; set; }

    public virtual User UidNavigation { get; set; } = null!;
}
