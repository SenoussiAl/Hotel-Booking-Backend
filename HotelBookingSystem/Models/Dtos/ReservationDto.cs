namespace HotelBookingSystem.Models.Dtos
{
    public class ReservationReadDto
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
        public int? CustomerId { get; set; }

        public string? HotelName { get; set; }
        public string? RoomNumber { get; set; }
        public string? CustomerName { get; set; }
    }

    public class ReservationCreateDto
    {
        public string? ReservationTitle { get; set; }
        public DateOnly? ReservationDate { get; set; }
        public int? DurationOfStay { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public decimal? ReservationCost { get; set; }
        public string? ReservationStatus { get; set; }
        public int? HotelId { get; set; }
        public int? RoomId { get; set; }
        public int? CustomerId { get; set; }
    }

    public class ReservationUpdateDto
    {
        public string? ReservationTitle { get; set; }
        public DateOnly? ReservationDate { get; set; }
        public int? DurationOfStay { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public decimal? ReservationCost { get; set; }
        public string? ReservationStatus { get; set; }
    }
}
