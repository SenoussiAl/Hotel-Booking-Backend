using Microsoft.AspNetCore.Mvc;
using HotelBookingSystem.Models.Services.ServicesImpl;
using HotelBookingSystem.Models.Services;
using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/hotels/[controller]")]
    public class HotelsController(IHotelService hotelService) : ControllerBase
    {
        private readonly IHotelService _hotelService = hotelService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelReadDto>>> GetAllHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelReadDto>> GetByHotelId(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
                return NotFound(new { Message = $"Hotel with ID {id} not found." });
                
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<HotelReadDto>> CreateHotel(HotelCreateDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdHotel = await _hotelService.CreateHotelAsync(hotelDto);
            return CreatedAtAction(nameof(GetByHotelId), new { id = createdHotel.HotelId }, createdHotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HotelReadDto>> UpdateHotel(int id, HotelUpdateDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedHotel = await _hotelService.UpdateHotelAsync(id, hotelDto);
            if (updatedHotel == null) 
                return NotFound();
            return Ok(updatedHotel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            var success = await _hotelService.DeleteHotelAsync(id);
            if (!success) 
                return NotFound(new { Message = $"Hotel with ID {id} not found." });
            return NoContent();
        }
    }
}
