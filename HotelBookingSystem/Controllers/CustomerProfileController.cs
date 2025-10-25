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
    
    }
    

}