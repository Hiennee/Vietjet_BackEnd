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
    }
}
