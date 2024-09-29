using System.ComponentModel.DataAnnotations;

namespace Vietjet_BackEnd.Models
{
    public class Aircraft
    {
        [MaxLength(300)]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public ICollection<Compartment> Compartments { get; set; }
    }
}
