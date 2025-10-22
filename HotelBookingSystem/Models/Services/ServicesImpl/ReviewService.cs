using AutoMapper;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models.Services.ServicesImpl
{
    public class ReviewService(AppDbContext context, IMapper mapper) : IReviewService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ReviewReadDto> CreateReviewAsync(ReviewCreateDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            var createdReview = _mapper.Map<ReviewReadDto>(review);
            return createdReview;
        }

        public Task<bool> DeleteReviewAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewReadDto>> GetAllReviewsFromHotelIdAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewReadDto?> GetRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewReadDto?> UpdateReviewAsync(int id, ReviewUpdateDto reviewDto)
        {
            throw new NotImplementedException();
        }
    }
}