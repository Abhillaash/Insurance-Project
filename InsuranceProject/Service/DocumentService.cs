using InsuranceProject.Repository;
using InsuranceProject.Service;
using InsuranceProject.DTOs;
using InsuranceProject.Model.Actors;

namespace InsuranceProject.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IEntityRepository<Document> _repository;

        public DocumentService(IEntityRepository<Document> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Document> GetAllDocuments()
        {
            return _repository.GetAll().ToList();
        }

        public Document GetDocumentById(int id)
        {
            return _repository.GetById(id);
        }

        public Document AddDocument(Document document)
        {
            _repository.Add(document);
            return document;
        }

        public Document UpdateDocument(Document document)
        {
            if (_repository.Update(document, document.DocumentId) != null)
            {
                return _repository.Update(document, document.DocumentId);
            }
            throw new Exception("No such document found");
        }

        public bool DeleteDocument(int id)
        {
            var deleteDocument = _repository.GetById(id);
            if (deleteDocument != null)
            {
                deleteDocument.Status = false;
                _repository.Delete(deleteDocument, deleteDocument.DocumentId);
                return true;
            }
            throw new DocumentNotFoundException("No such document");
        }
    }
}
