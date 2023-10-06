using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public interface IEmployeeService
    {


        public List<Employee> GetAll()
        ;

        public Employee GetById(int id)
        ;

        public Employee Add(Employee employee)
       ;

        public Employee Update(Employee employee);
        public bool Delete(int id)
        ;


    }
}
