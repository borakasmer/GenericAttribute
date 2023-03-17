﻿using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Modules
{
    public int Id { get; set; }

    public string ModuleName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Actions> Actions { get; } = new List<Actions>();

    public virtual ICollection<UserAction> UserAction { get; } = new List<UserAction>();
}
