using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public interface IInsurancePlanService
    {
        List<InsurancePlan> GetAllInsurancePlans();
        InsurancePlan GetInsurancePlanById(int id);
        InsurancePlan AddInsurancePlan(InsurancePlan insurancePlan);
        InsurancePlan UpdateInsurancePlan(InsurancePlan insurancePlan);
        bool DeleteInsurancePlan(int id);
    }
}
