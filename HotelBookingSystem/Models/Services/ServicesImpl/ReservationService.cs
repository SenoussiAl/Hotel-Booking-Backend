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
    public class ReservationService(AppDbContext context, IMapper mapper) : IReservationService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> IsRoomAvailableAsync(RoomAvailabilityDto roomAvailabilityDto)
        {
            var room = await _context.Rooms
                .Include(r => r.Reservations)
                .FirstOrDefaultAsync(r => r.RoomId == roomAvailabilityDto.RoomId);

            if (room == null)
                return false;

            bool isOverlapping = room.Reservations.Any(res =>
                roomAvailabilityDto.CheckInDate < res.CheckOutDate && 
                roomAvailabilityDto.CheckOutDate > res.CheckInDate
            );

            return !isOverlapping;
        }

        public async Task<IEnumerable<ReservationReadDto>> GetAllReservationsAsync()
        {
            var reservations = await _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.Hotel)
                .Include(r => r.Customer)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ReservationReadDto>>(reservations);
        }

        public async Task<ReservationReadDto?> GetReservationByIdAsync(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.Hotel)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.ReservationId == id);

            if (reservation == null)
                return null;

            return _mapper.Map<ReservationReadDto>(reservation);
        }

        public async Task<ReservationReadDto> CreateReservationAsync(ReservationCreateDto reservationDto)
        {
            var room = await _context.Rooms
                .Include(r => r.Reservations)
                .FirstOrDefaultAsync(r => r.RoomId == reservationDto.RoomId) ?? throw new KeyNotFoundException("Room not found");

            var availabilityDto = new RoomAvailabilityDto
            {
                RoomId = room.RoomId,
                CheckInDate = reservationDto.CheckInDate,
                CheckOutDate = reservationDto.CheckOutDate
            };

            if (!await IsRoomAvailableAsync(availabilityDto))
                throw new InvalidOperationException("Room is not available for the selected dates");

            var reservation = _mapper.Map<Reservation>(reservationDto);
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReservationReadDto>(reservation);
        }

        public async Task<ReservationReadDto?> UpdateReservationAsync(int id, ReservationUpdateDto reservationDto)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.ReservationId == id);

            if (reservation == null)
                return null;

            if (reservation.CheckInDate != reservationDto.CheckInDate || 
                reservation.CheckOutDate != reservationDto.CheckOutDate)
            {
                if (!reservation.RoomId.HasValue)
                    throw new InvalidOperationException("Reservation does not have a room assigned.");
                
                var availabilityDto = new RoomAvailabilityDto
                {
                    
                    RoomId = reservation.RoomId.Value,
                    CheckInDate = reservationDto.CheckInDate,
                    CheckOutDate = reservationDto.CheckOutDate
                };

                if (!await IsRoomAvailableAsync(availabilityDto))
                    throw new InvalidOperationException("Room is not available for the new dates");
            }

            _mapper.Map(reservationDto, reservation);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReservationReadDto>(reservation);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
                return false;

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
