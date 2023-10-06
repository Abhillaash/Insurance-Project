using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Model.Actors
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        [StringLength(100, ErrorMessage = "Role Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Staus is required")]
        public bool Status { get; set; }
    }
}
