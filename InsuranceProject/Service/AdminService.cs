using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;
using InsuranceProject.Service;
using InsuranceProject.Repository;


namespace InsuranceProject.Service
{
    public class AdminService : IAdminService
    {
        private readonly IEntityRepository<Admin> _repository;

        public AdminService(IEntityRepository<Admin> entityRepository)
        {
            _repository = entityRepository;
        }
        public List<Admin> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Admin GetById(int id)
        {

            return _repository.GetById(id);
        }
        public Admin Add(Admin admin)
        {


            _repository.Add(admin);
            return admin;

        }
        public Admin Update(Admin admin)
        {
            //var updateUser = _repository.GetById(user.UserId);
            if (_repository.Update(admin, admin.AdminId) != null)
            {
                return _repository.Update(admin, admin.AdminId);
            }
            throw new AdminNotFoundException("No such Admin found");


        }
        //public List<Admin> GetAllEmployee()
        //{
        //    return _repository.GetAllEmployee().ToList();
        //}
        //public Admin GetByIdEmployee(int EmployeeId, int AdminId)
        //{


        //    return _repository.GetByIdEmployee( EmployeeId,  AdminId);
        //}

        //public bool Delete(int id)
        //{
        //    var deleteAdmin = _repository.GetById(id);
        //    deleteAdmin.Status = false;
        //    if (deleteAdmin != null)
        //    {
        //        _repository.Delete(deleteAdmin, deleteAdmin.UserId);
        //        return true;
        //    }
        //    throw new UserNotFoundException("No such user");
        //}


        //}
        //public Employee AddEmployee(Employee employee)
        //{
        //    // Implement logic to add a new employee
        //    // You can perform validation, save to the database, etc.
        //    // Example:
        //    // if (IsValidEmployee(employee))
        //    // {
        //    //     return _adminRepository.AddEmployee(employee);
        //    // }
        //    // else
        //    // {
        //    //     throw new InvalidOperationException("Invalid employee data.");
        //    // }

        //    // Replace the above example logic with your actual implementation
        //    return _repository.AddEmployee(employee);
        //}

        //public Agent AddAgent(Agent agent)
        //{
        //    // Implement logic to add a new agent
        //    // You can perform validation, save to the database, etc.
        //    // Example:
        //    // if (IsValidAgent(agent))
        //    // {
        //    //     return _adminRepository.AddAgent(agent);
        //    // }
        //    // else
        //    // {
        //    //     throw new InvalidOperationException("Invalid agent data.");
        //    // }

        //    // Replace the above example logic with your actual implementation
        //    return _repository.AddAgent(agent);
        //}

        //public InsurancePlan AddInsurancePlan(InsurancePlan plan)
        //{
        //    // Implement logic to add a new insurance plan
        //    // You can perform validation, save to the database, etc.
        //    // Example:
        //    // if (IsValidInsurancePlan(plan))
        //    // {
        //    //     return _adminRepository.AddInsurancePlan(plan);
        //    // }
        //    // else
        //    // {
        //    //     throw new InvalidOperationException("Invalid insurance plan data.");
        //    // }

        //    // Replace the above example logic with your actual implementation
        //    return _repository.AddInsurancePlan(plan);
        //}

    }
}



