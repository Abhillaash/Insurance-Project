using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IEntityRepository<Customer> _repository;

        public CustomerService(IEntityRepository<Customer> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Customer GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Customer Add(Customer customer)
        {
            _repository.Add(customer);
            return customer;
        }

        public Customer Update(Customer customer)
        {
            var updatedCustomer = _repository.Update(customer, customer.CustomerId);
            if (updatedCustomer != null)
            {
                return updatedCustomer;
            }
            throw new CustomerNotFoundException("No such customer found");
        }
        public bool Delete(int id)
        {
            var deleteCustomer = _repository.GetById(id);
            if (deleteCustomer != null)
            {
                deleteCustomer.Status = false;
                _repository.Delete(deleteCustomer, deleteCustomer.CustomerId);
                return true;
            }
            throw new CustomerNotFoundException("No such customer");
        }
    }
}
