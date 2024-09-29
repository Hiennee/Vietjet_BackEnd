namespace Vietjet_BackEnd.Models
{
    public class Document
    {
        public string Id { get; set; }
        public string FlightId { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Pilot_roles { get; set; }
        public string Crew_roles { get; set; }
        public string Creator { get; set; }
        public Account Account_created { get; set; }
        public Flight Flight { get; set; }
        public ICollection<Document_Version> DocumentVersions { get; set; }
    }
}
