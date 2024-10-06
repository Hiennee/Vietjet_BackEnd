using Vietjet_BackEnd.DTO;
using Vietjet_BackEnd.Models;

namespace Vietjet_BackEnd.Services
{
    public class DocumentService
    {
        private readonly VietjetDbContext _context;
        public DocumentService(VietjetDbContext context)
        {
            _context = context;   
        }
        public ICollection<DocumentDTO> GetDocuments()
        {
            return (ICollection<DocumentDTO>)_context.Documents.ToList();
        }
        public DocumentDTO GetDocumentById(string id)
        {
            return _context.Documents.Where(d => d.Id == id).Select(d => new DocumentDTO
            {
                Id = d.Id,
                FlightId = d.FlightId,
                Type = d.Type,
                Note = d.Note,
                Pilot_roles = d.Pilot_roles,
                Crew_roles = d.Crew_roles,
                Creator = d.Creator,
            }).FirstOrDefault();
        }
        public ICollection<Document_VersionDTO> GetDocumentVersions(string id)
        {
            return (ICollection<Document_VersionDTO>)_context.Documents.Where(d => d.Id == id).SelectMany(d => d.DocumentVersions).ToList();
        }
        public Document_VersionDTO GetGetSpecificVersionOfDocument(string documentId, string versionId)
        {
            return _context.Documents.Where(d => d.Id == documentId)
                    .SelectMany(d => d.DocumentVersions)
                    .Where(dv => dv.Id == versionId)
                    .Select(dv => new Document_VersionDTO
                    {
                        Id = dv.Id,
                        DocumentId = dv.DocumentId,
                        Version = dv.Version,
                        CreateDate = dv.CreateDate,
                        Creator = dv.Creator,
                        Signature = dv.Signature
                    })
                    .FirstOrDefault();
        }
        public void PostDocument(string docName)
        {

        }
    }
}
