namespace HotelBookingSystem.Models.Dtos
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Username { get; set; } = null!;
    }

    public class CustomerCreateDto
    {
        public string CustomerName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string CustomerPassword { get; set; } = null!;
    }

    public class CustomerUpdateDto
    {
        public string CustomerName { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}
