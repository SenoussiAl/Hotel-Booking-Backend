using AutoMapper;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models.Dtos;
using HotelBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models.Services.ServicesImpl
{
    public class UserAccountSercive(HotelBookingDbContext context, IMapper mapper) : IUserAccountService
    {
        private readonly HotelBookingDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<UserAccountReadDto>> GetAllUserAccountsAsync()
        {
            var userAccounts = await _context.UserAccounts
                .Include(u => u.CustomerProfiles)
                .Include(u => u.Reservations)
                .Include(u => u.Reviews)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserAccountReadDto>>(userAccounts);
        }

        public async Task<UserAccountReadDto?> GetUserAccountByIdAsync(int id)
        {
            var userAccount = await _context.UserAccounts
                .Include(u => u.CustomerProfiles)
                .Include(u => u.Reservations)
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.UserId == id);
            if (userAccount == null)
                return null;
            return _mapper.Map<UserAccountReadDto>(userAccount);
        }

        public async Task<UserAccountReadDto> CreateUserAccountAsync(UserAccountCreateDto userAccountDto)
        {
            var userAccount = _mapper.Map<UserAccount>(userAccountDto);
            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            var createdUserAccount = _mapper.Map<UserAccountReadDto>(userAccount);
            return createdUserAccount;
        }

        public async Task<UserAccountReadDto?> UpdateUserAccountAsync(int id, UserAccountUpdateDto userAccountDto)
        {
            var userAccount = await _context.UserAccounts
                .FindAsync(id);

            if (userAccount == null)
                return null;
            
            _mapper.Map(userAccountDto, userAccount);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserAccountReadDto>(userAccount);
        }

        public async Task<bool> DeleteUserAccountAsync(int id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
                return false;
            _context.UserAccounts.Remove(userAccount);
            return true;
        }
    }
}