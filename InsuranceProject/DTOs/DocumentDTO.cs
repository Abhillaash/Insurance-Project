using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTOs
{
    public class DocumentDTO
    {
        [Key]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        [StringLength(50, ErrorMessage = "Document Type must be between {2} and {1} characters", MinimumLength = 2)]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Document Name is required")]
        [StringLength(100, ErrorMessage = "Document Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string DocumentName { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        [StringLength(50, ErrorMessage = "Document Type must be between {2} and {1} characters", MinimumLength = 2)]

        public string DocumentFile { get; set; }

        [Required(ErrorMessage = "Staus is required")]
        public bool Status { get; set; }
        public int? CustomerId { get; set; }

    }
}

