using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Models.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelReadDto>> GetAllHotelsAsync();
        Task<HotelReadDto?> GetHotelByIdAsync(int id);
        Task<HotelReadDto> CreateHotelAsync(HotelCreateDto hotelDto);
        Task<bool> UpdateHotelAsync(int id, HotelUpdateDto hotelDto);
        Task<bool> DeleteHotelAsync(int id);
    }
}
