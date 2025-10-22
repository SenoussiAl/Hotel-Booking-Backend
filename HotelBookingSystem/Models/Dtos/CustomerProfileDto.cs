namespace HotelBookingSystem.Models.Dtos
{
    public class UserprofileReadDto
    {
        public int ProfileId { get; set; }
        public string? UserFullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UserAddress { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
    public class UserprofileCreateDto
    {
        public string? UserFullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UserAddress { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public int? CustomerId { get; set; }
    }

    public class UserprofileUpdateDto
    {
        public string? UserFullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UserAddress { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
    }
}
