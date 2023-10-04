using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Model.Actors
{
    public class Agent
    {

        [Key]
        public int AgentId { get; set; }

        [Required(ErrorMessage = "Agent First Name is required")]
        [StringLength(50, ErrorMessage = "Agent First Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string AgentFirstName { get; set; }

        [Required(ErrorMessage = "Agent Last Name is required")]
        [StringLength(50, ErrorMessage = "Agent Last Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string AgentLastName { get; set; }

        [StringLength(100, ErrorMessage = "Qualification cannot exceed {1} characters")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number")]
        public string MobileNo { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Commission Earned is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Commission Earned must be a positive number")]
        public double CommissionEarned { get; set; }

        //[Required(ErrorMessage = "Status is required")]
        //[EnumDataType(typeof(CustomerStatus), ErrorMessage = "Invalid Status")]
        //public CustomerStatus Status { get; set; }
        public bool Status { get; set; }
        public List<Customer> Customers { get; set; }
    }
}



//using System.ComponentModel.DataAnnotations;

//public class Customer
//{

//}

//public enum CustomerStatus
//{
//    Active,
//    Inactive,
//    Suspended,
//    Terminated
//}

