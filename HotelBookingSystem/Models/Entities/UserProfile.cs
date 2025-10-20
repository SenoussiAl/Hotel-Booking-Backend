namespace HotelBookingSystem.Models.Entities;

public partial class Userprofile
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

    public virtual Customer? Customer { get; set; }
}
