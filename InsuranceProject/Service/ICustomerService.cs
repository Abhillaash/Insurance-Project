using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public interface ICustomerService
    {


        


        public List<Customer> GetAll();


        public Customer GetById(int id);


        public Customer Add(Customer customer);


        public Customer Update(Customer customer)
        ;
        public bool Delete(int id);
    }
}
