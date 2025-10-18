using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string CustomerPassword { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Userprofile> Userprofiles { get; set; } = new List<Userprofile>();
}
