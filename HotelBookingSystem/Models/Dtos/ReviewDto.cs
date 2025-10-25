namespace HotelBookingSystem.Models.Dtos
{
    public class ReviewReadDto
    {
        public int ReviewId { get; set; }

        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string ReviewText { get; set; } = null!;
        public int? Rating { get; set; }
        public DateOnly? ReviewDate { get; set; }

        public int? HotelId { get; set; }
        public string? HotelName { get; set; }
    }

    public class ReviewCreateDto
    {
        public int UserId { get; set; } 
        public int HotelId { get; set; }
        public string ReviewText { get; set; } = null!;
        public int? Rating { get; set; }
    }

    public class ReviewUpdateDto
    {
        public string ReviewText { get; set; } = null!;
        public int? Rating { get; set; }
    }
}
