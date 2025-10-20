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

            return _mapper.Map<IEnumerable<HotelReadDto>>(hotels);
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

            return dto;
        }

        public async Task<HotelReadDto> CreateHotelAsync(HotelCreateDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            var createdHotel = _mapper.Map<HotelReadDto>(hotel);
            return createdHotel;
        }


        public async Task<HotelReadDto?> UpdateHotelAsync(int id, HotelUpdateDto hotelDto)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
                return null;

            _mapper.Map(hotelDto, hotel);
            await _context.SaveChangesAsync();


            var updatedHotel = _mapper.Map<HotelReadDto>(hotel);
            return updatedHotel;
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
