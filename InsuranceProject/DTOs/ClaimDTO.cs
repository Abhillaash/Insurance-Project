using InsuranceProject.Model.Holdings;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTOs
{
    public class ClaimDTO
    {
        [Key]
        public int ClaimId { get; set; }

        


        [Required(ErrorMessage = "Claim Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Claim Amount must be a positive number")]
        public double ClaimAmount { get; set; }

        [Required(ErrorMessage = "Bank Account Number is required")]
        [RegularExpression(@"^\d{10,20}$", ErrorMessage = "Invalid Bank Account Number")]
        public string BankAccountNumber { get; set; }

        [Required(ErrorMessage = "Bank IFSC Code is required")]
        [StringLength(20, ErrorMessage = "IFSC Code must be between {2} and {1} characters", MinimumLength = 5)]
        public string BankIFSCCode { get; set; }

        //[Required(ErrorMessage = "Date is required")]
        //[DataType(DataType.Date)]
        //public DateTime Date { get; set; }

        [Required(ErrorMessage = "Staus is required")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "PolicyId is required")]
        public int? PocilyId { get; set; }
    }
}
