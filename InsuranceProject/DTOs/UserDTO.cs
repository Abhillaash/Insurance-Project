using InsuranceProject.Model.Actors;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username must be between {2} and {1} characters", MinimumLength = 2)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
        

        [Required(ErrorMessage = "Staus is required")]
        public bool Status { get; set; }

       
        public int? RoleId { get; set; }
    }
}
