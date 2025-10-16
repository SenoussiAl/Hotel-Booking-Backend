using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public string? Username { get; set; }

    public string ReviewText { get; set; } = null!;

    public int? Rating { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public int? HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
