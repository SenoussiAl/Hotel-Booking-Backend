using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Models.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomReadDto>> GetAllRoomsAsync();
        Task<IEnumerable<RoomReadDto>> GetAllRoomsFromHotelIdAsync(int hotelId);
        Task<HotelReadDto?> GetRoomByIdAsync(int id);
        Task<HotelReadDto> CreateRoomAsync(RoomCreateDto RoomDto);
        Task<bool> UpdateRoomAsync(int id, RoomUpdateDto RoomDto);
        Task<bool> DeleteRoomAsync(int id);
    }
}
