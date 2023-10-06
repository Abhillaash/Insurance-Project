using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public interface IInsurancePolicyService
    {
        List<InsurancePolicy> GetAll();
        InsurancePolicy GetById(int id);
        InsurancePolicy Add(InsurancePolicy insurancePolicy);
        InsurancePolicy Update(InsurancePolicy insurancePolicy);
        bool Delete(int id);
    }
}
