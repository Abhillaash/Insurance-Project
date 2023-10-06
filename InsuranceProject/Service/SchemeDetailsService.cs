using InsuranceProject.Model.Holdings;
using InsuranceProject.Repository;
using InsuranceProject.Exceptions;

namespace InsuranceProject.Service
{
    public class SchemeDetailsService : ISchemeDetailsService
    {
        private readonly IEntityRepository<SchemeDetails> _repository;

        public SchemeDetailsService(IEntityRepository<SchemeDetails> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<SchemeDetails> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public SchemeDetails GetById(int id)
        {
            return _repository.GetById(id);
        }

        public SchemeDetails Add(SchemeDetails schemeDetails)
        {
            _repository.Add(schemeDetails);
            return schemeDetails;
        }

        public SchemeDetails Update(SchemeDetails schemeDetails)
        {
            if (_repository.Update(schemeDetails, schemeDetails.DetailId) != null)
            {
                return _repository.Update(schemeDetails, schemeDetails.DetailId);
            }
            throw new Exception("No such scheme details found");
        }

        public bool Delete(int id)
        {
            var deleteSchemeDetails = _repository.GetById(id);
            if (deleteSchemeDetails != null)
            {
                _repository.Delete(deleteSchemeDetails, deleteSchemeDetails.DetailId);
                return true;
            }
            throw new SchemeDetailsNotFoundException("No such scheme details");
        }
    }
}
