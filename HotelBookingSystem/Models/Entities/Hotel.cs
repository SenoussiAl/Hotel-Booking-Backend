using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public decimal? Rating { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhones { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
