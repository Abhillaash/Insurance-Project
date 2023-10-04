using InsuranceProject.Model.Actors;
using InsuranceProject.Model.Holdings;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Model.Holdings
{
    public class InsurancePolicy
    {
        [Key]
        public int PolicyNo { get; set; }

        [Required(ErrorMessage = "Issue Date is required")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Maturity Date is required")]
        [DataType(DataType.Date)]
        public DateTime MaturityDate { get; set; }

        [Required(ErrorMessage = "Premium Type is required")]
        [StringLength(50, ErrorMessage = "Premium Type must be between {2} and {1} characters", MinimumLength = 2)]
        public string PremiumType { get; set; }

        [Required(ErrorMessage = "Premium Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Premium Amount must be a positive number")]
        public double PremiumAmount { get; set; }

        

        [Required(ErrorMessage = "Sum Assured is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Sum Assured must be a positive number")]
        public double SumAssured { get; set; }
        public bool Status { get; set; }

        //[Required(ErrorMessage = "Status is required")]
        //[EnumDataType(typeof(PolicyStatus), ErrorMessage = "Invalid Status")]
        //public PolicyStatus Status { get; set; }

        // Navigation property for payments associated with this policy
        public InsuranceScheme InsuranceScheme { get; set; }
        public List<Claim> Claims { get; set; }
        public List<Payment> Payments { get; set; }
       

    }


}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//public class InsurancePolicy
//{

//}

//public enum PolicyStatus
//{
//    Active,
//    Inactive,
//    Terminated
//}

