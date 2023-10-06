using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public interface IInsuranceSchemeService
    {
        List<InsuranceScheme> GetAllInsuranceSchemes();
        InsuranceScheme GetInsuranceSchemeById(int id);
        InsuranceScheme AddInsuranceScheme(InsuranceScheme insuranceScheme);
        InsuranceScheme UpdateInsuranceScheme(InsuranceScheme insuranceScheme);
        bool DeleteInsuranceScheme(int id);
    }
}
