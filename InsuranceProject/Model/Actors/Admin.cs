using InsuranceProject.Model.Holdings;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Model.Actors
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Admin First Name is required")]
        [StringLength(50, ErrorMessage = "Admin First Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string AdminFirstName { get; set; }

        [Required(ErrorMessage = "Admin Last Name is required")]
        [StringLength(50, ErrorMessage = "Admin Last Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string AdminLastName { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; }

        public List<InsurancePlan> InsurancePlans { get; set; }
        public List<InsuranceScheme> InsuranceSchemes { get; set; }
        public List<InsurancePolicy> InsurancePolicies { get; set; }
        public List<Employee> Employees { get; set; }
    }
}





