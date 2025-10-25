using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(ICustomerProfileService customerProfileService) : ControllerBase
    {
        private readonly ICustomerProfileService _customerProfileService = customerProfileService;
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerProfileReadDto>>> GetAllCustomerProfiles()
        {
            var customerProfiles = await _customerProfileService.GetAllCustomerProfilesAsync();
            return Ok(customerProfiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerProfileReadDto>> GetCustomerProfileById(int id)
        {
            var customerProfile = await _customerProfileService.GetCustomerProfileByIdAsync(id);
            if (customerProfile == null)
                return NotFound(new { Message = $"CustomerProfile with ID {id} not found." });

            return Ok(customerProfile);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<CustomerProfileReadDto>> GetCustomerProfileByUserId(int userId)
        {
            var customerProfile = await _customerProfileService.GetCustomerProfileByUserIdAsync(userId);
            if (customerProfile == null)
                return NotFound(new { Message = $"CustomerProfile with ID {userId} not found."});

            return Ok(customerProfile);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerProfileReadDto>> CreateCustomerProfile(CustomerProfileCreateDto customerProfileDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCustomerProfile = await _customerProfileService.CreateCustomerProfileAsync(customerProfileDto);
            return CreatedAtAction(nameof(GetCustomerProfileById), new { id = createdCustomerProfile.CustomerId}, createdCustomerProfile);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerProfileReadDto>> Update(int id, CustomerProfileUpdateDto customerProfileDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCustomerProfile = await _customerProfileService.UpdateCustomerProfileAsync(id, customerProfileDto);
            if (updatedCustomerProfile == null)
                return NotFound(new { Message = $"CustomerProfile with ID {id} not found." });
            return Ok(updatedCustomerProfile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerProfile(int id)
        {
            var success = await _customerProfileService.DeleteCustomerProfileAsync(id);

            if (!success)
                return NotFound(new { Message = $"CustomerProfile with ID {id} not found." });

            return NoContent();
        }
    }
}
