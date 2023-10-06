using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceProject.Model.Holdings
{
    public class SchemeDetails
    {
        [Key]
        public int DetailId { get; set; }

        [Required(ErrorMessage = "Scheme Image is required")]
        public string SchemeImage { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Minimum Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum Amount must be a positive number")]
        public double MinAmount { get; set; }

        [Required(ErrorMessage = "Maximum Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Maximum Amount must be a positive number")]
        public double MaxAmount { get; set; }

        [Required(ErrorMessage = "Minimum Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Minimum Age must be a positive number")]
        public int MinAge { get; set; }

        [Required(ErrorMessage = "Maximum Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Maximum Age must be a positive number")]
        public int MaxAge { get; set; }

        [Required(ErrorMessage = "Profit Ratio is required")]
        [Range(0, 100, ErrorMessage = "Profit Ratio must be between {2} and {1}")]
        public double ProfitRatio { get; set; }

        [Required(ErrorMessage = "Registration Commission Ratio is required")]
        [Range(0, 100, ErrorMessage = "Registration Commission Ratio must be between {2} and {1}")]
        public double RegistrationCommRatio { get; set; }

        [Required(ErrorMessage = "Installment Commission Ratio is required")]
        [Range(0, 100, ErrorMessage = "Installment Commission Ratio must be between {2} and {1}")]
        public double InstallmentCommRatio { get; set; }

        [Required(ErrorMessage = "Minimum Investment Time is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Minimum Investment Time must be a positive number")]
        public int MinInvestTime { get; set; }

        [Required(ErrorMessage = "Maximum Investment Time is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Maximum Investment Time must be a positive number")]
        public int MaxInvestTime { get; set; }

        [Required(ErrorMessage = "Staus is required")]
        public bool Status { get; set; }


        public InsuranceScheme InsuranceScheme { get; set; }
  
        
        public int? SchemeId { get; set; }

    }
}



