using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController(IReviewService reviewService) : ControllerBase
    {
        private readonly IReviewService _reviewService = reviewService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewReadDto>>> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<ReviewReadDto>> GetAllReviewsByHotelId(int hotelId)
        {
            var reviews = await _reviewService.GetAllReviewsByHotelIdAsync(hotelId);
            if (reviews == null)
                return NotFound(new { Message = $"No Reviews for this Hotel found."});
            return Ok(reviews);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ReviewReadDto>> GetAllReviewsByUserId(int userId)
        {
            var reviews = await _reviewService.GetAllReviewsByUserIdAsync(userId);
            if (reviews == null)
                return NotFound(new { Message = $"No Reviews with ID {userId} found."});
            return Ok(reviews);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ReviewReadDto>> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
                return NotFound(new { Message = $"Review with ID {id} not found." });
            return Ok(review);
        }
        
        [HttpPost]
        public async Task<ActionResult<ReviewReadDto>> CreateReview(ReviewCreateDto reviewDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdReview = await _reviewService.CreateReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.ReviewId }, createdReview);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewReadDto>> UpdateReview(int id, ReviewUpdateDto reviewDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedReview = await _reviewService.UpdateReviewAsync(id, reviewDto);
            if (updatedReview == null)
                return NotFound(new { Message = $"Review with ID {id} not found." });
            return Ok(updatedReview);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var success = await _reviewService.DeleteReviewAsync(id);

            if (!success)
                return NotFound(new { Message = $"Review with ID {id} not found." });

            return NoContent();
        }
    }
}