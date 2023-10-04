using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Model.Holdings
{
    public class InsurancePlan
    {
        [Key]
        public int PlanId { get; set; }

        [Required(ErrorMessage = "Plan Name is required")]
        [StringLength(100, ErrorMessage = "Plan Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string PlanName { get; set; }


        public bool Status { get; set; }

        public List<InsuranceScheme> InsuranceSchemes { get; set; }
    }
}




//using System.ComponentModel.DataAnnotations;

//public class InsurancePlan
//{
//[Required(ErrorMessage = "Status is required")]
//[EnumDataType(typeof(PlanStatus), ErrorMessage = "Invalid Status")]
//public PlanStatus Status { get; set; }
//}

//public enum PlanStatus
//{
//    Active,
//    Inactive
//}

