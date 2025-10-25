using AutoMapper;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;

namespace HotelBookingSystem.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelReadDto>()
                .ForMember(dest => dest.RoomCount, opt => opt.MapFrom(src => src.Rooms != null ? src.Rooms.Count : 0))
                .ForMember(dest => dest.ReviewCount, opt => opt.MapFrom(src => src.Reviews != null ? src.Reviews.Count : 0));

            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<HotelUpdateDto, Hotel>();

            CreateMap<Room, RoomReadDto>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel != null ? src.Hotel.HotelName : null))
                .ForMember(dest => dest.ReservationCount, opt => opt.MapFrom(src => src.Reservations.Count));
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();

            CreateMap<Reservation, ReservationReadDto>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel != null ? src.Hotel.HotelName : null))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room != null ? src.Room.RoomNumber : null))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User!= null ? src.User.Username : null));
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<ReservationUpdateDto, Reservation>();

            CreateMap<Review, ReviewReadDto>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel != null ? src.Hotel.HotelName : null))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null ? src.User.Username : null));
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<ReviewUpdateDto, Review>();

            CreateMap<UserAccount, UserAccountReadDto>();
            CreateMap<UserAccountCreateDto, UserAccount>();
            CreateMap<UserAccountUpdateDto, UserAccount>();

            CreateMap<CustomerProfile, CustomerProfileReadDto>()
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null ? src.User.Username : null));
            CreateMap<CustomerProfileCreateDto, CustomerProfile>();
            CreateMap<CustomerProfileUpdateDto, CustomerProfile>();
        }
    }
}
