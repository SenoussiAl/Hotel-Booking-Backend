using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Models.Services
{
    public interface IReservationService
    {

        Task<bool> IsRoomAvailableAsync(RoomAvailabilityDto roomAvailabilityDto);
        Task<IEnumerable<ReservationReadDto>> GetAllReservationsAsync();
        Task<IEnumerable<ReservationReadDto>> GetAllReservationsByUserIdAsync(int userId);
        Task<ReservationReadDto?> GetReservationByIdAsync(int id);
        Task<ReservationReadDto> CreateReservationAsync(ReservationCreateDto reservationDto);
        Task<ReservationReadDto?> UpdateReservationAsync(int id, ReservationUpdateDto reservationDto);
        Task<bool> DeleteReservationAsync(int id);
        
    }
}