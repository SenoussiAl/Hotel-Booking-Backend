namespace HotelBookingSystem.Models.Dtos
{
    public class HotelReadDto
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; } = null!;
        public decimal? Rating { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhones { get; set; }
        public string? Address { get; set; }

        public int RoomCount { get; set; }
        public int ReviewCount { get; set; }
    }

    public class HotelCreateDto
    {
        public string HotelName { get; set; } = null!;
        public decimal? Rating { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhones { get; set; }
        public string? Address { get; set; }
    }

    public class HotelUpdateDto
    {
        public string HotelName { get; set; } = null!;
        public decimal? Rating { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhones { get; set; }
        public string? Address { get; set; }
    }

}
