using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings
using InsuranceProject.Service
using InsuranceProject.Repository;


namespace InsuranceProject.Service
{
    public class AdminService : IAdminService
    {
        private readonly IEntityRepository _repository;

        public AdminService(IEntityRepository entityRepository)
        {
            _repository = entityRepository;
        }
        public List<User> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public User GetById(int id)
        {

            return _repository.GetById(id);
        }
        public User Add(Admin admin)
        {


            _repository.Add(admin);
            return admin;

        }
        public User Update(Admin admin)
        {
            //var updateUser = _repository.GetById(user.UserId);
            if (_repository.Update(admin, admin.UserId) != null)
            {
                return _repository.Update(admin, admin.UserId);
            }
            throw new UserNotFoundException("No such user found");


        }

        public bool Delete(int id)
        {
            var deleteAdmin = _repository.GetById(id);
            deleteAdmin.IsActive = false;
            if (deleteAdmin != null)
            {
                _repository.Delete(deleteAdmin, deleteAdmin.UserId);
                return true;
            }
            throw new UserNotFoundException("No such user");



        }
        public Employee AddEmployee(Employee employee)
        {
            // Implement logic to add a new employee
            // You can perform validation, save to the database, etc.
            // Example:
            // if (IsValidEmployee(employee))
            // {
            //     return _adminRepository.AddEmployee(employee);
            // }
            // else
            // {
            //     throw new InvalidOperationException("Invalid employee data.");
            // }

            // Replace the above example logic with your actual implementation
            return _adminRepository.AddEmployee(employee);
        }

        public Agent AddAgent(Agent agent)
        {
            // Implement logic to add a new agent
            // You can perform validation, save to the database, etc.
            // Example:
            // if (IsValidAgent(agent))
            // {
            //     return _adminRepository.AddAgent(agent);
            // }
            // else
            // {
            //     throw new InvalidOperationException("Invalid agent data.");
            // }

            // Replace the above example logic with your actual implementation
            return _adminRepository.AddAgent(agent);
        }

        public InsurancePlan AddInsurancePlan(InsurancePlan plan)
        {
            // Implement logic to add a new insurance plan
            // You can perform validation, save to the database, etc.
            // Example:
            // if (IsValidInsurancePlan(plan))
            // {
            //     return _adminRepository.AddInsurancePlan(plan);
            // }
            // else
            // {
            //     throw new InvalidOperationException("Invalid insurance plan data.");
            // }

            // Replace the above example logic with your actual implementation
            return _adminRepository.AddInsurancePlan(plan);
        }
    }
}



