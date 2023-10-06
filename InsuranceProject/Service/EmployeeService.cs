using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEntityRepository<Employee> _repository;

        public EmployeeService(IEntityRepository<Employee> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Employee> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Employee GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Employee Add(Employee employee)
        {
            _repository.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            if (_repository.Update(employee, employee.EmployeeId) != null)
            {
                return _repository.Update(employee, employee.EmployeeId);
            }
            throw new EmployeeNotFoundException("No such employee found");
        }
        public bool Delete(int id)
        {
            var deleteEmployee = _repository.GetById(id);
            if (deleteEmployee != null)
            {
                deleteEmployee.Status = false;
                _repository.Delete(deleteEmployee, deleteEmployee.EmployeeId);
                return true;
            }
            throw new EmployeeNotFoundException("No such employee");
        }

    }
}
