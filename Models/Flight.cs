using System.ComponentModel.DataAnnotations;

namespace Vietjet_BackEnd.Models
{
    public class Flight
    {
        [MaxLength(300)]
        public string Id { get; set; }
        public string AircraftId { get; set; }
        public string Route { get; set; }
        public DateTime DepartmentDate { get; set; }
        public string LoadingPoint { get; set; }
        public string UnloadingPoint { get; set; }
        public bool Confirmed { get; set; }
        public Aircraft Aircraft { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Compartment> Compartments { get; set; }
    }
}
