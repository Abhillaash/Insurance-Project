using InsuranceProject.Repository;
using InsuranceProject.Model.Actors;

namespace InsuranceProject.Service
{
    public interface IDocumentService
    {
        

        public List<Document> GetAllDocuments()
        ;

        public Document GetDocumentById(int id)
        ;

        public Document AddDocument(Document document)
        ;

        public Document UpdateDocument(Document document)
        ;

        public bool DeleteDocument(int id)
        ;
    }
}
