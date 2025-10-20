namespace HotelBookingSystem.Models.Dtos
{
    public class RoomReadDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string? RoomType { get; set; }
        public int? NumBeds { get; set; }
        public decimal PricePerNight { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }
        public string? HotelName { get; set; }
        public int ReservationCount { get; set; }
    }

    public class RoomCreateDto
    {
        public string RoomNumber { get; set; } = null!;
        public string? RoomType { get; set; }
        public int? NumBeds { get; set; }
        public decimal PricePerNight { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }
    }

    public class RoomUpdateDto
    {
        public string RoomNumber { get; set; } = null!;
        public string? RoomType { get; set; }
        public int? NumBeds { get; set; }
        public decimal PricePerNight { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? Description { get; set; }
    }
}
