using InsuranceProject.Model.Holdings;
using InsuranceProject.Repository;
using InsuranceProject.Exceptions;

namespace InsuranceProject.Service
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly IEntityRepository<InsurancePolicy> _repository;

        public InsurancePolicyService(IEntityRepository<InsurancePolicy> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<InsurancePolicy> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public InsurancePolicy GetById(int id)
        {
            return _repository.GetById(id);
        }

        public InsurancePolicy Add(InsurancePolicy insurancePolicy)
        {
            _repository.Add(insurancePolicy);
            return insurancePolicy;
        }

        public InsurancePolicy Update(InsurancePolicy insurancePolicy)
        {
            if (_repository.Update(insurancePolicy, insurancePolicy.PolicyNo) != null)
            {
                return _repository.Update(insurancePolicy, insurancePolicy.PolicyNo);
            }
            throw new Exception("No such insurance policy found");
        }

        public bool Delete(int id)
        {
            var deleteInsurancePolicy = _repository.GetById(id);
            if (deleteInsurancePolicy != null)
            {
                deleteInsurancePolicy.Status = false;
                _repository.Delete(deleteInsurancePolicy, deleteInsurancePolicy.PolicyNo);
                return true;
            }
            throw new InsurancePolicyNotFoundException("No such insurance policy");
        }
    }
}
