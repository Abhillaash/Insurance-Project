using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTOs
{
    public class QueryDTO
    {
        [Key]
        public int QueryId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must be between {2} and {1} characters", MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, ErrorMessage = "Message must be between {2} and {1} characters", MinimumLength = 2)]
        public string Message { get; set; }

        [Required(ErrorMessage = "Contact Date is required")]
        [DataType(DataType.Date)]
        public DateTime ContactDate { get; set; }

        public string Reply { get; set; }
        [Required(ErrorMessage = "Staus is required")]
        public bool Status { get; set; }

        public int? CustomerId { get; set; }

    }
}
