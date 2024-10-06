using Microsoft.EntityFrameworkCore;
using Vietjet_BackEnd.DTO;
using Vietjet_BackEnd.Models;

namespace Vietjet_BackEnd.Services
{
    public class FlightService
    {
        private readonly VietjetDbContext _context;
        public FlightService(VietjetDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<FlightDTO>> GetFlights()
        {
            return await _context.Flights.Select(f => new FlightDTO
            {
                Id = f.Id,
                AircraftId = f.AircraftId,
                Route = f.Route,
                DepartmentDate = f.DepartmentDate,
                LoadingPoint = f.LoadingPoint,
                UnloadingPoint = f.UnloadingPoint,
                Confirmed = f.Confirmed,
            }).ToListAsync();
        }
        public async Task<FlightDTO> GetFlight(string id)
        {
            return await _context.Flights.Where(f => f.Id == id).Select(f => new FlightDTO
            {
                Id = f.Id,
                AircraftId = f.AircraftId,
                Route = f.Route,
                DepartmentDate = f.DepartmentDate,
                LoadingPoint = f.LoadingPoint,
                UnloadingPoint = f.UnloadingPoint,
                Confirmed = f.Confirmed,
            }).FirstOrDefaultAsync();
        }
        public async Task<bool> IsFlightConfirmed(string id)
        {
            return await _context.Flights.Select(f => f.Confirmed == true).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Document>> GetDocumentsOfFlight(string id)
        {
            return await _context.Flights.Where(f => f.Id == id).SelectMany(f => f.Documents).ToListAsync();
        }
        public async Task<ICollection<Compartment>> GetCompartmentsOfFlight(string id)
        {
            return await _context.Flights.Where(f => f.Id == id).SelectMany(f => f.Compartments).ToListAsync();
        }
        public async Task<AircraftDTO> GetAircraftOfFlight(string id)
        {
            return await _context.Flights.Where(f => f.Id == id).Select(f => f.Aircraft).Select(a => new AircraftDTO
            {
                Id = a.Id,
                Name = a.Name,
            }).FirstOrDefaultAsync();
        }
    }
}
