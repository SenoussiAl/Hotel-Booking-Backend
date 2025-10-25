namespace HotelBookingSystem.Models.Entities;

public partial class CustomerProfile
{
    public int CustomerId { get; set; }

    public string? CustomerFirstName { get; set; }
    
    public string? CustomerLastName { get; set; }

    public string? Phone { get; set; }
    public string? CustomerAddress { get; set; }

    public string? Nationality { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Gender { get; set; }

    public int? UserId { get; set; }

    public virtual UserAccount? User { get; set; }
}
