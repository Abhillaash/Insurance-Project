using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceProject.Model.Holdings
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        [StringLength(50, ErrorMessage = "Payment Type must be between {2} and {1} characters", MinimumLength = 2)]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Tax is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Tax must be a positive number")]
        public double Tax { get; set; }

        [Required(ErrorMessage = "Total Payment is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Payment must be a positive number")]
        public double TotalPayment { get; set; }




        public InsurancePolicy InsurancePolicy { get; set; }

        [ForeignKey("InsurancePolicy")]
        public int? PocilyId { get; set; }
    }
}



