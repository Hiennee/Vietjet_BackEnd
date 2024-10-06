using Microsoft.EntityFrameworkCore;
using Vietjet_BackEnd.DTO;
using Vietjet_BackEnd.Models;

namespace Vietjet_BackEnd.Services
{
    public class AircraftService
    {
        private readonly VietjetDbContext _context;
        public AircraftService(VietjetDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<AircraftDTO>> GetAircrafts()
        {
            return await _context.Aircrafts.Select(ac => new AircraftDTO
            {
                Id = ac.Id,
                Name = ac.Name,
            }).ToListAsync();
        }
        public async Task<AircraftDTO> GetAircraft(string id)
        {
            return await _context.Aircrafts.Where(ac => ac.Id == id)
                .Select(ac => new AircraftDTO
                {
                    Id = ac.Id,
                    Name = ac.Name,
                }).FirstOrDefaultAsync();
        }
        public async Task<bool> PostAircraft(string id, string name)
        {
            try
            {
                _context.Aircrafts.Add(new Aircraft
                {
                    Id = id,
                    Name = name,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateAircraft(AircraftDTO aircraft)
        {
            try
            {
                var result = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == aircraft.Id);
                if (result == null)
                    throw new Exception("Aircraft not found");
                result.Name = aircraft.Name;
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
