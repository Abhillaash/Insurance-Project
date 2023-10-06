using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTOs
{
    public class InsuranceSchemeDTO
    {
        [Key]
        public int SchemeId { get; set; }
        [Required(ErrorMessage = "Scheme Name are required")]
        [StringLength(100, ErrorMessage = "Scheme Name must be between {2} and {1} characters", MinimumLength = 2)]

        public string SchemeName { get; set; }

        public int? PlanId { get; set; }

        public bool Status { get; set; }
    }
}
