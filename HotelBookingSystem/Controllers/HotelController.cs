using Microsoft.AspNetCore.Mvc;
using HotelBookingSystem.Models.Services.ServicesImpl;
using HotelBookingSystem.Models.Services;
using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelReadDto>>> GetAll()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelReadDto>> GetById(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<HotelReadDto>> Create(HotelCreateDto hotelDto)
        {
            var createdHotel = await _hotelService.CreateHotelAsync(hotelDto);
            return CreatedAtAction(nameof(GetById), new { id = createdHotel.HotelId }, createdHotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HotelReadDto>> Update(int id, HotelUpdateDto hotelDto)
        {
            var updatedHotel = await _hotelService.UpdateHotelAsync(id, hotelDto);
            if (updatedHotel == null) return NotFound();
            return Ok(updatedHotel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _hotelService.DeleteHotelAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
