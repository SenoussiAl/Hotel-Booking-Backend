using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(HotelBookingDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.UserAccounts.Any())
            {
                var users = new List<UserAccount>
                {
                    new UserAccount { Username = "john_doe", UserPassword = "Password123!", UserEmail = "john@example.com", Role = "customer" },
                    new UserAccount { Username = "admin_user", UserPassword = "AdminPass!23", UserEmail = "admin@example.com", Role = "admin" }
                };

                context.UserAccounts.AddRange(users);
                await context.SaveChangesAsync();
            }

            if (!context.CustomerProfiles.Any())
            {
                var profiles = new List<CustomerProfile>
                {
                    new CustomerProfile
                    {
                        CustomerFirstName = "John",
                        CustomerLastName = "Doe",
                        Phone = "123-456-7890",
                        CustomerAddress = "123 Main St, Ottawa, Canada",
                        Nationality = "Canadian",
                        MaritalStatus = "Single",
                        Gender = "Male",
                        UserId = 1
                    }
                };

                context.CustomerProfiles.AddRange(profiles);
                await context.SaveChangesAsync();
            }

            if (!context.Hotels.Any())
            {
                var hotels = new List<Hotel>
                {
                    new Hotel { HotelName = "Grand Palace Hotel", Rating = 4.5m, Address = "789 Wellington St, Ottawa, Canada", ContactEmail = "contact@grandpalace.com", ContactPhones = "555-111-2222" },
                    new Hotel { HotelName = "Sunset Resort", Rating = 4.2m, Address = "12 Beach Ave, Miami, USA", ContactEmail = "info@sunsetresort.com", ContactPhones = "555-333-9999" }
                };

                context.Hotels.AddRange(hotels);
                await context.SaveChangesAsync();
            }

            if (!context.Rooms.Any())
            {
                var rooms = new List<Room>
                {
                    new Room { RoomNumber = "101", RoomType = "Deluxe Suite", NumBeds = 2, PricePerNight = 250.00m, Description = "Spacious room with city view", HotelId = 1 },
                    new Room { RoomNumber = "102", RoomType = "Standard Room", NumBeds = 1, PricePerNight = 120.00m, Description = "Comfortable standard room", HotelId = 1 },
                    new Room { RoomNumber = "201", RoomType = "Ocean View Suite", NumBeds = 2, PricePerNight = 300.00m, Description = "Suite with ocean view balcony", HotelId = 2 }
                };

                context.Rooms.AddRange(rooms);
                await context.SaveChangesAsync();
            }

            if (!context.Reservations.Any())
            {
                var reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        ReservationTitle = "John's Ottawa Stay",
                        ReservationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        DurationOfStay = 3,
                        CheckInDate = new DateOnly(2025, 11, 1),
                        CheckOutDate = new DateOnly(2025, 11, 4),
                        ReservationCost = 750.00m,
                        ReservationStatus = "Confirmed",
                        HotelId = 1,
                        RoomId = 1,
                        UserId = 1
                    },
                    new Reservation
                    {
                        ReservationTitle = "Weekend Getaway",
                        ReservationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        DurationOfStay = 2,
                        CheckInDate = new DateOnly(2025, 11, 10),
                        CheckOutDate = new DateOnly(2025, 11, 12),
                        ReservationCost = 240.00m,
                        ReservationStatus = "Pending",
                        HotelId = 1,
                        RoomId = 2,
                        UserId = 1
                    }
                };

                context.Reservations.AddRange(reservations);
                await context.SaveChangesAsync();
            }

            if (!context.Reviews.Any())
            {
                var reviews = new List<Review>
                {
                    new Review
                    {
                        Username = "john_doe",
                        ReviewText = "Amazing service and clean rooms. Highly recommended!",
                        Rating = 5,
                        ReviewDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        HotelId = 1,
                        UserId = 1
                    },
                    new Review
                    {
                        Username = "john_doe",
                        ReviewText = "Good value but room was a bit small.",
                        Rating = 3,
                        ReviewDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        HotelId = 1,
                        UserId = 1
                    }
                };

                context.Reviews.AddRange(reviews);
                await context.SaveChangesAsync();
            }
        }
    }
}
