using InsuranceProject.Model.Actors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceProject.DTOs
{
    public class InsurancePolicyDTO
    {
        [Key]
        public int PocilyId { get; set; }

        [Required(ErrorMessage = "Policy Number is required")]
        [Display(Name = "Policy Number")] // Optional: Set the display name
        public int PolicyNo { get; set; }


        [Required(ErrorMessage = "Issue Date is required")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Maturity Date is required")]
        [DataType(DataType.Date)]
        public DateTime MaturityDate { get; set; }

        [Required(ErrorMessage = "Premium Type is required")]
        [StringLength(50, ErrorMessage = "Premium Type must be between {2} and {1} characters", MinimumLength = 2)]
        public string PremiumType { get; set; }

        [Required(ErrorMessage = "Premium Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Premium Amount must be a positive number")]
        public double PremiumAmount { get; set; }



        [Required(ErrorMessage = "Sum Assured is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Sum Assured must be a positive number")]
        public double SumAssured { get; set; }
        public bool Status { get; set; }
        public int? PlanId { get; set; }

      
        public int? CustomerId { get; set; }
    }
}
