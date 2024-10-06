using Microsoft.AspNetCore.Mvc;
using Vietjet_BackEnd.DTO;
using Vietjet_BackEnd.Models;
using Vietjet_BackEnd.Services;

namespace Vietjet_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private DocumentService _service;
        public DocumentController(DocumentService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetDocuments()
        {
            var result = _service.GetDocuments();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetDocumentById([FromRoute(Name = "id")] string id)
        {
            var result = _service.GetDocumentById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("{id}/versions")]
        public ActionResult GetDocumentVersions([FromRoute(Name = "id")] string id)
        {
            var result = _service.GetDocumentVersions(id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("{documentId}/{versionId}")]
        public ActionResult GetSpecificVersionOfDocument([FromRoute(Name = "documentId")] string documentId,
                                                         [FromRoute(Name = "versionId")] string versionId)
        {
            var result = _service.GetGetSpecificVersionOfDocument(documentId, versionId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpPost("post")]
        public async Task<IActionResult> PostDocument([FromBody] DocumentDTO document)
        {
            if (await _service.PostDocument(document.Name, document.Type, document.Note, document.Creator, document.Pilot_roles, document.Crew_roles) == true)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAccount([FromBody] dynamic requestBody)
        {
            if (await _service.UpdateDocument(requestBody))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
