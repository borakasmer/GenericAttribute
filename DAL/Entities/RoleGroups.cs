using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class RoleGroups
{
    public int Id { get; set; }

    public string? GroupName { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Roles> Roles { get; } = new List<Roles>();

    public virtual ICollection<UserRoles> UserRoles { get; } = new List<UserRoles>();
}
