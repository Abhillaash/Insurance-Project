using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Model.Actors
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username must be between {2} and {1} characters", MinimumLength = 2)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
