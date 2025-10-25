using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController(IRoomService roomService) : ControllerBase
    {
        private readonly IRoomService _roomService = roomService;

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>>GetRoomsByHotelId(int hotelId)
        {
            var rooms = await _roomService.GetAllRoomsFromHotelIdAsync(hotelId);
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomReadDto>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
                return NotFound(new { Message = $"Room with ID {id} not found." });

            return Ok(room);
        }

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> SearchRoom([FromBody] RoomSearchDto searchDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rooms = await _roomService.SearchRoomsAsync(searchDto);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult<RoomReadDto>> CreateRoom(RoomCreateDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdRoom = await _roomService.CreateRoomAsync(roomDto);
            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.RoomId }, createdRoom);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<RoomReadDto>> UpdateRoom(int id, RoomUpdateDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedRoom = await _roomService.UpdateRoomAsync(id, roomDto);
            if (updatedRoom == null)
                return NotFound(new { Message = $"Room with ID {id} not found." });
            return Ok(updatedRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var success = await _roomService.DeleteRoomAsync(id);

            if (!success)
                return NotFound(new { Message = $"Room with ID {id} not found." });

            return NoContent();
        }
    }
}
