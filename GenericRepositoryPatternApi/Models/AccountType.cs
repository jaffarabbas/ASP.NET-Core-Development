using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class AccountType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool AcStatus { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
