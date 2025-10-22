namespace HotelBookingSystem.Models.Entities
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string? RoomType { get; set; }
        public int? NumBeds { get; set; }
        public decimal PricePerNight { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
