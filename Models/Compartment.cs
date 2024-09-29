using System.ComponentModel.DataAnnotations;

namespace Vietjet_BackEnd.Models
{
    public class Compartment
    {
        [MaxLength(300)]
        public string FlightId { get; set; }
        [MaxLength(300)]
        public string AircraftId { get; set; }
        [MaxLength(300)]
        public string CompartmentId { get; set; }
        public int Arrival { get; set; }
        public int LoadingInstruction { get; set; }
        public int LoadingReport { get; set; }
        public Flight Flight { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
