using AutoMapper;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models.Services.ServicesImpl
{
    public class RoomService(AppDbContext context, IMapper mapper) : IRoomService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<RoomReadDto>> GetAllRoomsAsync()
        {
            var rooms = await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.Reservations)
                .ToListAsync();

            return _mapper.Map<IEnumerable<RoomReadDto>>(rooms);
        }



        public async Task<IEnumerable<RoomReadDto>> GetAllRoomsFromHotelIdAsync(int hotelId)
        {
            var rooms = await _context.Rooms
                .Where(r => r.HotelId == hotelId)
                .Include(r => r.Hotel)
                .Include(r => r.Reservations)
                .ToListAsync();
                
            return _mapper.Map<IEnumerable<RoomReadDto>>(rooms);
        }

        public async Task<RoomReadDto?> GetRoomByIdAsync(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.Reservations)
                .FirstOrDefaultAsync(r => r.RoomId == id);
            if (room == null)
                return null;

            return _mapper.Map<RoomReadDto>(room);
        }


        public async Task<IEnumerable<RoomReadDto>> SearchRoomsAsync(RoomSearchDto searchDto)
        {
            var query = _context.Rooms
                .Include(r => r.Reservations)
                .Include(r => r.Hotel)
                .AsQueryable();

            if (searchDto.MinPrice.HasValue)
                query = query.Where(r => r.PricePerNight >= searchDto.MinPrice.Value);

            if (searchDto.MaxPrice.HasValue)
                query = query.Where(r => r.PricePerNight <= searchDto.MaxPrice.Value);

            if (searchDto.NumBeds.HasValue)
                query = query.Where(r => r.NumBeds == searchDto.NumBeds.Value);

            var checkInDateOnly = DateOnly.FromDateTime(searchDto.CheckIn);
            var checkOutDateOnly = DateOnly.FromDateTime(searchDto.CheckOut);
            query = query.Where(r => !r.Reservations.Any(res =>
                checkInDateOnly < res.CheckOutDate && checkOutDateOnly > res.CheckInDate
            ));

            var rooms = await query.ToListAsync();
            return _mapper.Map<IEnumerable<RoomReadDto>>(rooms);
        }


        public async Task<RoomReadDto> CreateRoomAsync(RoomCreateDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            var createdRoom = _mapper.Map<RoomReadDto>(room);
            return createdRoom;

        }
        public async Task<RoomReadDto?> UpdateRoomAsync(int id, RoomUpdateDto roomDto)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
                return null;

            _mapper.Map(roomDto, room);
            await _context.SaveChangesAsync();

            var updatedRoom = _mapper.Map<RoomReadDto>(room);
            return updatedRoom;
        }
        public async Task<bool> DeleteRoomAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
                return false;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}