namespace Vietjet_BackEnd.DTO
{
    public class FlightDTO
    {
        public string Id { get; set; }
        public string AircraftId { get; set; }
        public string Route { get; set; }
        public DateTime DepartmentDate { get; set; }
        public string LoadingPoint { get; set; }
        public string UnloadingPoint { get; set; }
        public bool Confirmed { get; set; }
    }
}
