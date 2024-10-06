namespace Vietjet_BackEnd.DTO
{
    public class Document_VersionDTO
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string DocumentId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Creator { get; set; }
        public string Signature { get; set; }
    }
}
