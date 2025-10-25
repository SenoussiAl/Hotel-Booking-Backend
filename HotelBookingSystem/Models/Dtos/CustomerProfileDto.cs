namespace HotelBookingSystem.Models.Dtos
{
    public class CustomerProfileReadDto
    {
        public int ProfileId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public int? CustomerId { get; set; }
        public string? Username { get; set; }
    }
    public class CustomerProfileCreateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public int? CustomerId { get; set; }
    }

    public class CustomerProfileUpdateDto
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
    }
}
