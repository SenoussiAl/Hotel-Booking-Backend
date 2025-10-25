namespace HotelBookingSystem.Models.Dtos
{
    public class UserAccountReadDto
    {
        public int UserId { get; set; } 
        public string Username { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string? Role { get; set; }
    }

    public class UserAccountCreateDto
    {
        public string Username { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string? Role { get; set; } 
    }

    public class UserAccountUpdateDto
    {
        public string Username { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
