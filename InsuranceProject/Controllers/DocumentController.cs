using InsuranceProject.Service;
using InsuranceProject.DTOs;
using InsuranceProject.Model.Actors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("GetAllDocuments")]
        public IActionResult GetAllDocuments()
        {
            var documents = _documentService.GetAllDocuments();

            var documentDTOs = new List<DocumentDTO>();
            foreach (var document in documents)
            {
                var documentDTO = ConvertToDocumentDTO(document);
                documentDTOs.Add(documentDTO);
            }

            return Ok(documentDTOs);
        }


        [HttpGet("GetDocument/{id}")]
        public IActionResult GetDocument(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }
            var documentDTO = ConvertToDocumentDTO(document);
            return Ok(documentDTO);
        }

        [HttpPost("AddDocument")]
        public IActionResult AddDocument([FromBody] DocumentDTO documentDTO)
        {
            var newDocument = ConvertToDocument(documentDTO);
            var document = _documentService.AddDocument(newDocument);
            if (document != null)
            {
                return CreatedAtAction(nameof(GetAllDocuments), document.DocumentId);
            }
            return BadRequest("Document cannot be created");
        }

        [HttpPut("UpdateDocument")]
        public IActionResult UpdateDocument([FromBody] DocumentDTO documentDTO)
        {
            var newDocument = ConvertToDocument(documentDTO);
            newDocument.DocumentId = documentDTO.DocumentId; // Assuming you have a DocumentId property in DocumentDTO
            var updatedDocument = _documentService.UpdateDocument(newDocument);
            return Ok(updatedDocument.DocumentId);
        }

        // Add other actions as needed
        [HttpDelete("DeleteDocument/{id}")]
        public IActionResult DeleteDocumentById(int id)
        {
            var isRemoved = _documentService.DeleteDocument(id);

            if (isRemoved)
            {
                return Ok("Document Removed Successfully");
            }

            return NotFound("Document not found");
        }

        private Document ConvertToDocument(DocumentDTO documentDTO)
        {
            return new Document
            {
                DocumentId = documentDTO.DocumentId,
                DocumentType = documentDTO.DocumentType,
                DocumentName = documentDTO.DocumentName,
                DocumentFile = documentDTO.DocumentFile,
                Status=documentDTO.Status
                
                // Add other property mappings as needed
            };
        }

        private DocumentDTO ConvertToDocumentDTO(Document document)
        {
            return new DocumentDTO
            {
                DocumentId = document.DocumentId,
                DocumentType = document.DocumentType,
                DocumentName = document.DocumentName,
                DocumentFile = document.DocumentFile,
                Status = document.Status
                
                // Add other property mappings as needed
            };
        }

    }
}
