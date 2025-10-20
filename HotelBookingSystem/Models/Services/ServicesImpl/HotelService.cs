using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models.Services.ServicesImpl
{
    public class HotelService(AppDbContext context, IMapper mapper) : IHotelService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<HotelReadDto>> GetAllHotelsAsync()
        {
            var hotels = await _context.Hotels
                .Include(h => h.Rooms)
                .Include(h => h.Reviews)
                .ToListAsync();

            var hotelDtos = _mapper.Map<IEnumerable<HotelReadDto>>(hotels);

            foreach (var dto in hotelDtos)
            {
                var entity = hotels.First(h => h.HotelId == dto.HotelId);
                dto.RoomCount = entity.Rooms.Count;
                dto.ReviewCount = entity.Reviews.Count;
            }

            return hotelDtos;
        }

        public async Task<HotelReadDto?> GetHotelByIdAsync(int id)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Rooms)
                .Include(h => h.Reviews)
                .FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return null;

            var dto = _mapper.Map<HotelReadDto>(hotel);
            dto.RoomCount = hotel.Rooms.Count;
            dto.ReviewCount = hotel.Reviews.Count;

            return dto;
        }

        public async Task<HotelReadDto> CreateHotelAsync(HotelCreateDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            var createdHotel = _mapper.Map<HotelReadDto>(hotel);
            createdHotel.RoomCount = 0;
            createdHotel.ReviewCount = 0;
            return createdHotel;
        }

        public async Task<bool> UpdateHotelAsync(int id, HotelUpdateDto hotelDto)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
                return false;

            _mapper.Map(hotelDto, hotel);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
                return false;

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
