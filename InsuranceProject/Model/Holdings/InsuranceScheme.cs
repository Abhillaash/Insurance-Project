using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceProject.Model.Holdings
{
    public class InsuranceScheme
    {
        [Key]
        public int SchemeId { get; set; }
        [Required(ErrorMessage = "Scheme Name are required")]
        [StringLength(100, ErrorMessage = "Scheme Name must be between {2} and {1} characters", MinimumLength = 2)]

        public string SchemeName { get; set; }



        public bool Status { get; set; }
        
        public InsurancePlan InsurancePlan { get; set; }

        [ForeignKey("InsurancePlan")]
    
        public int? PlanId { get; set; }
        public List<SchemeDetails>? SchemeDetails { get; set; }

        public List<InsurancePolicy>? InsurancePolicies { get; set; }



    }
}


//using System.ComponentModel.DataAnnotations;

//public class InsuranceScheme
//{
//[Required(ErrorMessage = "Status is required")]
//[EnumDataType(typeof(SchemeStatus), ErrorMessage = "Invalid Status")]
//public SchemeStatus Status { get; set; }
//}

//public enum SchemeStatus
//{
//    Active,
//    Inactive
//}

