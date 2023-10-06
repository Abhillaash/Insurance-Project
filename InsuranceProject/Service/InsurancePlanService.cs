using InsuranceProject.Model.Holdings;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class InsurancePlanService : IInsurancePlanService
    {
        private readonly IEntityRepository<InsurancePlan> _repository;

        public InsurancePlanService(IEntityRepository<InsurancePlan> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<InsurancePlan> GetAllInsurancePlans()
        {
            return _repository.GetAll().ToList();
        }

        public InsurancePlan GetInsurancePlanById(int id)
        {
            return _repository.GetById(id);
        }

        public InsurancePlan AddInsurancePlan(InsurancePlan insurancePlan)
        {
            _repository.Add(insurancePlan);
            return insurancePlan;
        }

        public InsurancePlan UpdateInsurancePlan(InsurancePlan insurancePlan)
        {
            if (_repository.Update(insurancePlan, insurancePlan.PlanId) != null)
            {
                return _repository.Update(insurancePlan, insurancePlan.PlanId);
            }
            throw new InsurancePlanNotFoundException("No such insurance plan found");
        }

        public bool DeleteInsurancePlan(int id)
        {
            var deleteInsurancePlan = _repository.GetById(id);
            if (deleteInsurancePlan != null)
            {
                deleteInsurancePlan.Status = false;
                _repository.Delete(deleteInsurancePlan, deleteInsurancePlan.PlanId);
                return true;
            }
            throw new InsurancePlanNotFoundException("No such insurance plan");
        }
    }
}
