using AutoMapper;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models.Services.ServicesImpl
{
    public class CustomerProfileService(HotelBookingDbContext context, IMapper mapper) : ICustomerProfileService
    {
        private readonly HotelBookingDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<IEnumerable<CustomerProfileReadDto>> GetAllCustomerProfilesAsync()
        {
            var customerProfiles = await _context.CustomerProfiles
                .Include(c => c.User)
                .ToListAsync();
            return _mapper.Map<IEnumerable<CustomerProfileReadDto>>(customerProfiles);
        }

        public async Task<CustomerProfileReadDto?> GetCustomerProfileByCustomerIdAsync(int customerId)
        {
            var customerProfile = await _context.CustomerProfiles
                .Include(cp => cp.User)
                .FirstOrDefaultAsync(cp => cp.CustomerId == customerId);
            if (customerProfile == null)
                return null;
            return _mapper.Map<CustomerProfileReadDto>(customerProfile);
        }

        public async Task<CustomerProfileReadDto?> GetCustomerProfileByUserIdAsync(int userId)
        {
            var customerProfile = await _context.CustomerProfiles
                .Include(cp => cp.User)
                .FirstOrDefaultAsync(cp => cp.UserId == userId);
            if (customerProfile == null)
                return null;
            return _mapper.Map<CustomerProfileReadDto>(customerProfile);
        }

        public async Task<CustomerProfileReadDto> CreateCustomerProfileAsync(CustomerProfileCreateDto customerProfileDto)
        {
            var customerProfile = _mapper.Map<CustomerProfile>(customerProfileDto);
            _context.CustomerProfiles.Add(customerProfile);
            await _context.SaveChangesAsync();

            var createdCustomerProfile = _mapper.Map<CustomerProfileReadDto>(customerProfile);
            return createdCustomerProfile;
        }

        public async Task<CustomerProfileReadDto?> UpdateCustomerProfileAsync(int id, CustomerProfileUpdateDto customerProfileDto)
        {
            var customerProfile = await _context.CustomerProfiles
                .FindAsync(id);

            if (customerProfile == null)
                return null;
            _mapper.Map(customerProfileDto, customerProfile);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerProfileReadDto>(customerProfile);

        }
        
        public async Task<bool> DeleteCustomerProfileAsync(int id)
        {
            var customerProfile = await _context.CustomerProfiles.FindAsync(id);

            if (customerProfile == null)
                return false;

            _context.CustomerProfiles.Remove(customerProfile);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}