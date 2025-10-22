using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Models.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync();
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsFromHotelIdAsync(int hotelId);
        Task<ReviewReadDto?> GetRoomByIdAsync(int id);
        Task<ReviewReadDto> CreateReviewAsync(ReviewCreateDto reviewDto);
        Task<ReviewReadDto?> UpdateReviewAsync(int id, ReviewUpdateDto reviewDto);
        Task<bool> DeleteReviewAsync(int id);
    }
}
