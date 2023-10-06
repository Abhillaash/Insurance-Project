using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace InsuranceProject.Model.Actors
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee First Name is required")]
        [StringLength(50, ErrorMessage = "Employee First Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "Employee Last Name is required")]
        [StringLength(50, ErrorMessage = "Employee Last Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string EmployeeLastName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public double Salary { get; set; }
        public User User { get; set; }
  
        
        public int? UserId { get; set; }

        
        public bool Status { get; set; }
        public List<Agent> Agents { get; set; }

        public Admin Admin { get; set; }

        
        public int? AdminId { get; set; }
        //public List<Claim> Claims { get; set; }


    }
}


//using System.ComponentModel.DataAnnotations;

//public class Employee
//{

//}

//public enum EmployeeStatus
//{
//    Active,
//    Inactive,
//    Suspended,
//    Terminated
//}
