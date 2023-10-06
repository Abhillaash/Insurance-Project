using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public interface IAdminService
    {
        public List<Admin> GetAll();


        public Admin GetById(int id);

        public Admin Add(Admin admin);

        public Admin Update(Admin admin)
       ;
        //public List<Admin> GetAllEmployee();

       // public Employee AddEmployee(Employee employee)
       // ;

        // public Agent AddAgent(Agent agent)
        // ;

        // public InsurancePlan AddInsurancePlan(InsurancePlan plan)
        //;
    }
}
