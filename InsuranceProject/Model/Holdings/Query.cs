using InsuranceProject.Model.Actors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceProject.Model.Holdings
{
    public class Query
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

        [Required(ErrorMessage = "Staus is required")]
        public bool Status { get; set; }

        public string Reply { get; set; }

        // Assuming a relationship with the Customer class
        public Customer Customer { get; set; }
       
        
        public int? CustomerId { get; set; }


    }
}
