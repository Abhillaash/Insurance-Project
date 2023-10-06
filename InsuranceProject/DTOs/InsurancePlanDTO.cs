using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTOs
{
    public class InsurancePlanDTO
    {
        [Key]
        public int PlanId { get; set; }

        [Required(ErrorMessage = "Plan Name is required")]
        [StringLength(100, ErrorMessage = "Plan Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string PlanName { get; set; }


        public bool Status { get; set; }
        public int? AdminId { get; set; }
    }
}
