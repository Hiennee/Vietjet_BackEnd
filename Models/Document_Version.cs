namespace Vietjet_BackEnd.Models
{
    public class Document_Version
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string DocumentId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Creator { get; set; }
        public string Signature { get; set; }
        public Document Document { get; set; }
        public Account Issuer { get; set; }
    }
}
