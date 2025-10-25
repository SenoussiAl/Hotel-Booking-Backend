using AutoMapper;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models.Services.ServicesImpl
{
    public class ReviewService(HotelBookingDbContext context, IMapper mapper) : IReviewService
    {
        private readonly HotelBookingDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync()
        {
            var reviews = await _context.Reviews
                .Include(r => r.Hotel)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ReviewReadDto>>(reviews);
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsFromHotelIdAsync(int hotelId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.HotelId == hotelId)
                .Include(r => r.Hotel)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ReviewReadDto>>(reviews);
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsFromUserIdAsync(int userId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.UserId == userId)
                .Include(r => r.Hotel)
                .Include(r => r.User)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ReviewReadDto>>(reviews);
        }

        public async Task<ReviewReadDto?> GetReviewByIdAsync(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(r => r.ReviewId == id);

            if (review == null)
                return null;

            return _mapper.Map<ReviewReadDto>(review);
        }

        public async Task<ReviewReadDto> CreateReviewAsync(ReviewCreateDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            var createdReview = _mapper.Map<ReviewReadDto>(review);
            return createdReview;
        }

        public async Task<ReviewReadDto?> UpdateReviewAsync(int id, ReviewUpdateDto reviewDto)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
                return null;

            _mapper.Map(reviewDto, review);
            await _context.SaveChangesAsync();

            var updatedReview = _mapper.Map<ReviewReadDto>(review);
            return updatedReview;
        }
     
        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}