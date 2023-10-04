
using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Model
{
    public class ModelContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<InsuranceScheme> InsuranceSchemes { get; set; }
        public DbSet<SchemeDetails> SchemeDetails { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<Query> Queries { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Claim> Claims { get; set; }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }
        //public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }
    }
}
//using Microsoft.EntityFrameworkCore;
//using InsuranceProject.Holdings; // Import your entity classes namespace

//namespace InsuranceProject.Data
//{
//    public class InsuranceContext : DbContext
//    {
//        // Define DbSet properties for your entity classes
        

       

//        // Add any additional configuration or methods as needed
//    }
//}

