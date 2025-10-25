using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Models.Services
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccountReadDto>> GetAllUserAccountsAsync();
        Task<UserAccountReadDto?> GetUserAccountByIdAsync(int id);
        Task<UserAccountReadDto> CreateUserAccountAsync(UserAccountCreateDto userAccountDto);
        Task<UserAccountReadDto?> UpdateUserAccountAsync(int id, UserAccountUpdateDto userAccountDto);
        Task<bool> DeleteUserAccountAsync(int id);
    }
}