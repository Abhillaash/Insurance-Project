using InsuranceProject.Model.Holdings;
using InsuranceProject.Repository;
using InsuranceProject.Exceptions;


namespace InsuranceProject.Service
{
    public class InsuranceSchemeService: IInsuranceSchemeService
    {
        private readonly IEntityRepository<InsuranceScheme> _repository;

        public InsuranceSchemeService(IEntityRepository<InsuranceScheme> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<InsuranceScheme> GetAllInsuranceSchemes()
        {
            return _repository.GetAll().ToList();
        }

        public InsuranceScheme GetInsuranceSchemeById(int id)
        {
            return _repository.GetById(id);
        }

        public InsuranceScheme AddInsuranceScheme(InsuranceScheme insuranceScheme)
        {
            _repository.Add(insuranceScheme);
            return insuranceScheme;
        }

        public InsuranceScheme UpdateInsuranceScheme(InsuranceScheme insuranceScheme)
        {
            if (_repository.Update(insuranceScheme, insuranceScheme.SchemeId) != null)
            {
                return _repository.Update(insuranceScheme, insuranceScheme.SchemeId);
            }
            throw new Exception("No such insurance scheme found");
        }

        public bool DeleteInsuranceScheme(int id)
        {
            var deleteInsuranceScheme = _repository.GetById(id);
            if (deleteInsuranceScheme != null)
            {
                deleteInsuranceScheme.Status = false;
                _repository.Delete(deleteInsuranceScheme, deleteInsuranceScheme.SchemeId);
                return true;
            }
            throw new InsuranceSchemeNotFoundException("No such insurance scheme");
        }
    }
}
