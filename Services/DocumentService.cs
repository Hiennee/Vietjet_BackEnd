using Microsoft.EntityFrameworkCore;
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
                Name = d.Name,
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
        public ICollection<Document> GetDocumentsByName(string name)
        {
            return _context.Documents.Where(d => EF.Functions.Like(d.Name, $"%{name}%")).ToList();
        }
        public async Task<bool> PostDocument(string docName, string type, string note, string creator, string p_roles, string c_roles)
        {
            try
            {
                _context.Documents.Add(new Document
                {
                    Name = docName,
                    Type = type,
                    Note = note,
                    Pilot_roles = p_roles,
                    Crew_roles = c_roles,
                    Creator = creator,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateDocument(DocumentDTO doc)
        {
            try
            {
                var result = await _context.Documents.FirstOrDefaultAsync(d => d.Id == doc.Id);
                if (result == null)
                {
                    throw new Exception("Account not found");
                }
                result.Name = doc.Name;
                result.Type = doc.Type;
                result.Pilot_roles = doc.Pilot_roles;
                result.Crew_roles = doc.Crew_roles;
                result.FlightId = doc.FlightId;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
