namespace HotelBookingSystem.Models.Entities;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public string? ReservationTitle { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public int? DurationOfStay { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public decimal? ReservationCost { get; set; }

    public string? ReservationStatus { get; set; }

    public int? HotelId { get; set; }

    public int? RoomId { get; set; }

    public int? UserId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Room? Room { get; set; }

    public virtual UserAccount? User { get; set; }
}
