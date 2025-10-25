using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;
using HotelBookingSystem.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController(IReservationService reservationService) : ControllerBase
    {
        private readonly IReservationService _reservationService = reservationService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetAllReversations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            if (reservations == null)
                return NotFound(new { Message = $"No Reservation found."});
            return Ok(reservations);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ReservationReadDto>> GetAllReservationsByUserId(int userId)
        {
            var reservations= await _reservationService.GetAllReservationsByUserIdAsync(userId);
            if (reservations == null)
                return NotFound(new { Message = $"No Reservation with ID {userId} found."});
            return Ok(reservations);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ReservationReadDto>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
                return NotFound(new { Message = $"Reservation with ID {id} not found." });
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationReadDto>> CreateReview(ReservationCreateDto reservationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdReservation = await _reservationService.CreateReservationAsync(reservationDto);
            return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.ReservationId }, createdReservation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationReadDto>> UpdateReservation(int id, ReservationUpdateDto reservationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedReservation = await _reservationService.UpdateReservationAsync(id, reservationDto);
            if (updatedReservation == null)
                return NotFound(new { Message = $"Reservation with ID {id} not found." });
            return Ok(updatedReservation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRservation(int id)
        {
            var success = await _reservationService.DeleteReservationAsync(id);

            if (!success)
                return NotFound(new { Message = $"Reservation with ID {id} not found." });

            return NoContent();
        }
    }
}