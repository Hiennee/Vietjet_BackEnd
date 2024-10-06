using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        public async Task<bool> Register(string username, string password, string email, string phone, string role)
        {
            try
            {
                _context.Accounts.Add(new Account
                {
                    Name = username,
                    Password = password,
                    Email = email,
                    Phone = phone,
                    Role = role,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task<bool> UpdateAccount(AccountDTO account)
        {
            try
            {
                var result = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == account.Id);
                if (result == null) 
                    throw new Exception("Account not found");
                result.Name = account.Name;
                result.Phone = account.Phone;
                result.Email = account.Email;
                result.Role = account.Role;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<bool> Suspend(string id, DateTime due)
        {
            try
            {
                var result = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
                if (result == null)
                    throw new Exception("Account not found");
                result.Terminated_until = due;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
