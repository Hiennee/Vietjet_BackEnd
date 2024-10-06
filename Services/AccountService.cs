using Microsoft.EntityFrameworkCore;
using Vietjet_BackEnd.DTO;
using Vietjet_BackEnd.Models;

namespace Vietjet_BackEnd.Services
{
    public class AccountService
    {
        private readonly VietjetDbContext _context;
        public AccountService(VietjetDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<AccountDTO>> GetAccounts()
        {
            return await _context.Accounts.Select(a => new AccountDTO
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                Phone = a.Phone,
                Role = a.Role,
                Terminated_until = a.Terminated_until,
            }).ToListAsync();
        }
        public async Task<AccountDTO> GetAccount(string id)
        {
            return await _context.Accounts.Where(a => a.Id == id).Select(a => new AccountDTO
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                Phone = a.Phone,
                Role = a.Role,
                Terminated_until = a.Terminated_until,
            }).FirstOrDefaultAsync();
        }
        public async Task<bool> IsAccountSuspended(string id)
        {
            var terminated_until = await _context.Accounts.Where(a => a.Id == id).Select(a => a.Terminated_until).FirstOrDefaultAsync();
            return (terminated_until.HasValue && terminated_until > DateTime.Now);
        }
        public async Task<Account> Login(string username, string password)
        {
            username = username.ToLower();
            var result = await _context.Accounts.Where(a => a.Email == username).Where(a => a.Password == password).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
