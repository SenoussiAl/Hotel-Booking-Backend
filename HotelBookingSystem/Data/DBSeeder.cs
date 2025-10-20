using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Entities;

public static class DbSeeder
{
    public static async Task SeedHotelsAsync(AppDbContext context)
    {
        if (!context.Hotels.Any())
        {
            var hotels = new List<Hotel>
            {
                new Hotel { HotelName = "Grand Palace", Rating = 4.5m, Address = "123 Main St", ContactEmail = "info@grandpalace.com", ContactPhones = "123-456-7890" },
                new Hotel { HotelName = "Sea View Resort", Rating = 4.0m, Address = "456 Ocean Ave", ContactEmail = "contact@seaview.com", ContactPhones = "987-654-3210" },
                new Hotel { HotelName = "Mountain Lodge", Rating = 3.8m, Address = "789 Hill Rd", ContactEmail = "hello@mountainlodge.com", ContactPhones = "555-123-4567" }
            };

            context.Hotels.AddRange(hotels);
            await context.SaveChangesAsync();
        }
    }
}
