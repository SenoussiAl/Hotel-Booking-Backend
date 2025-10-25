using HotelBookingSystem.Models.Dtos;

namespace HotelBookingSystem.Models.Services
{
    public interface ICustomerProfileService
    {
        Task<IEnumerable<CustomerProfileReadDto>> GetAllCustomerProfilesAsync();
        Task<CustomerProfileReadDto?> GetCustomerProfileByIdAsync(int id);
        Task<CustomerProfileReadDto?> GetCustomerProfileByUserIdAsync(int userId);
        Task<CustomerProfileReadDto> CreateCustomerProfileAsync(CustomerProfileCreateDto customerProfileDto);
        Task<CustomerProfileReadDto?> UpdateCustomerProfileAsync(int id, CustomerProfileUpdateDto customerProfileDto);
        Task<bool> DeleteCustomerProfileAsync(int id);
    }
}