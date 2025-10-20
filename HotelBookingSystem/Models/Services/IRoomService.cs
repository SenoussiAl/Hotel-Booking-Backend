using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Models.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomReadDto>> GetAllRoomsAsync();
        Task<IEnumerable<RoomReadDto>> GetAllRoomsFromHotelIdAsync(int hotelId);
        Task<RoomReadDto?> GetRoomByIdAsync(int id);
        Task<IEnumerable<RoomReadDto>> SearchRoomsAsync(RoomSearchDto searchDto);
        Task<RoomReadDto> CreateRoomAsync(RoomCreateDto roomDto);
        Task<RoomReadDto?> UpdateRoomAsync(int id, RoomUpdateDto roomDto);
        Task<bool> DeleteRoomAsync(int id);
    }
}
