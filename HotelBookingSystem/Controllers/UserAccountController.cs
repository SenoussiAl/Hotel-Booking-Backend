using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountsController(IUserAccountService userAccountService) : ControllerBase
    {
        private readonly IUserAccountService _userAccountService = userAccountService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccountReadDto>>> GetAllUserAccounts()
        {
            var userAccounts = await _userAccountService.GetAllUserAccountsAsync();
            return Ok(userAccounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccountReadDto>> GetUserAccountById(int id)
        {
            var userAccount = await _userAccountService.GetUserAccountByIdAsync(id);
            if (userAccount == null)
                return NotFound(new { Message = $"UserAccount with ID {id} not found." });

            return Ok(userAccount);
        }
        [HttpPost]
        public async Task<ActionResult<UserAccountReadDto>> CreateUserAccount(UserAccountCreateDto userAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUserAccount = await _userAccountService.CreateUserAccountAsync(userAccountDto);
            return CreatedAtAction(nameof(GetUserAccountById), new { id = createdUserAccount.UserId }, createdUserAccount);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserAccountReadDto>> Update(int id, UserAccountUpdateDto userAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedUserAccount = await _userAccountService.UpdateUserAccountAsync(id, userAccountDto);
            if (updatedUserAccount == null)
                return NotFound(new { Message = $"UserAccount with ID {id} not found." });
            return Ok(updatedUserAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount(int id)
        {
            var success = await _userAccountService.DeleteUserAccountAsync(id);

            if (!success)
                return NotFound(new { Message = $"UserAccount with ID {id} not found." });

            return NoContent();
        }
    }
}