using System.ComponentModel.DataAnnotations;

namespace Vietjet_BackEnd.DTO
{
    public class CompartmentDTO
    {
        public string FlightId { get; set; }
        public string AircraftId { get; set; }
        public string CompartmentId { get; set; }
        public int Arrival { get; set; }
        public int LoadingInstruction { get; set; }
        public int LoadingReport { get; set; }
    }
}
