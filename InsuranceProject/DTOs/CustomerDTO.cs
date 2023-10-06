using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTOs
{
    public class CustomerDTO
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(100, ErrorMessage = "State must be between {2} and {1} characters", MinimumLength = 2)]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City must be between {2} and {1} characters", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "Nominee is required")]
        [StringLength(100, ErrorMessage = "Nominee must be between {2} and {1} characters", MinimumLength = 2)]
        public string Nominee { get; set; }

        [Required(ErrorMessage = "Nominee Relation is required")]
        [StringLength(100, ErrorMessage = "Nominee Relation must be between {2} and {1} characters", MinimumLength = 2)]
        public string NomineeRelation { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public bool Status { get; set; }
    }
}
