using AutoMapper;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;

namespace HotelBookingSystem.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ---------------- Hotels ----------------
            CreateMap<Hotel, HotelReadDto>();
            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<HotelUpdateDto, Hotel>();

            // ---------------- Rooms ----------------
            CreateMap<Room, RoomReadDto>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel != null ? src.Hotel.HotelName : null))
                .ForMember(dest => dest.ReservationCount, opt => opt.MapFrom(src => src.Reservations.Count));
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();

            // ---------------- Reservations ----------------
            CreateMap<Reservation, ReservationReadDto>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel != null ? src.Hotel.HotelName : null))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room != null ? src.Room.RoomNumber : null))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.CustomerName : null));
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<ReservationUpdateDto, Reservation>();

            // ---------------- Reviews ----------------
            CreateMap<Review, ReviewReadDto>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel != null ? src.Hotel.HotelName : null));
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<ReviewUpdateDto, Review>();

            // ---------------- Customers ----------------
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();

            // ---------------- Userprofiles ----------------
            CreateMap<Userprofile, UserprofileReadDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.CustomerName : null));
            CreateMap<UserprofileCreateDto, Userprofile>();
            CreateMap<UserprofileUpdateDto, Userprofile>();
        }
    }
}
