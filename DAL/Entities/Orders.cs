﻿using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Orders
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public decimal? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }

    public virtual Customers? Customer { get; set; }

    public virtual Employees? Employee { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();

    public virtual Shippers? ShipViaNavigation { get; set; }
}
