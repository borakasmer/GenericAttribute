﻿using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class QuarterlyOrders
{
    public string? CustomerId { get; set; }

    public string? CompanyName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
