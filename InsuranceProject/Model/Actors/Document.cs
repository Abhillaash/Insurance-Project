using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Model.Actors
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        [StringLength(50, ErrorMessage = "Document Type must be between {2} and {1} characters", MinimumLength = 2)]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Document Name is required")]
        [StringLength(100, ErrorMessage = "Document Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string DocumentName { get; set; }

        [Required(ErrorMessage = "Document File is required")]
        public byte[] DocumentFile { get; set; }
    }
}



