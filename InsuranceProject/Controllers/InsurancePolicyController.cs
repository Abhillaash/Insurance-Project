using InsuranceProject.DTOs;
using InsuranceProject.Model.Holdings;
using InsuranceProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly IInsurancePolicyService _insurancePolicyService;

        public InsurancePolicyController(IInsurancePolicyService insurancePolicyService)
        {
            _insurancePolicyService = insurancePolicyService;
        }

        //[HttpGet("GetAllPolicies")]
        //public IActionResult GetAllPolicies()
        //{
        //    var policies = _insurancePolicyService.GetAll();
        //    return Ok(policies);
        //}

        [HttpGet("GetAllInsurancePolicies")]
        public IActionResult GetAllInsurancePolicies()
        {
            var insurancePolicies = _insurancePolicyService.GetAll();

            var insurancePolicyDTOs = new List<InsurancePolicyDTO>();
            foreach (var policy in insurancePolicies)
            {
                var policyDTO = ConvertToInsurancePolicyDTO(policy);
                insurancePolicyDTOs.Add(policyDTO);
            }

            return Ok(insurancePolicyDTOs);
        }


        [HttpGet("GetPolicy/{id}")]
        public IActionResult GetPolicy(int policyNo)
        {
            var policy = _insurancePolicyService.GetById(policyNo);
            if (policy == null)
            {
                return NotFound();
            }
            var policyDTO = ConvertToInsurancePolicyDTO(policy);
            return Ok(policyDTO);
        }

        [HttpPost("AddPolicy")]
        public IActionResult AddPolicy([FromBody] InsurancePolicyDTO policyDTO)
        {
            var newPolicy = ConvertToInsurancePolicy(policyDTO);
            var policy = _insurancePolicyService.Add(newPolicy);
            if (policy != null)
            {
                return CreatedAtAction(nameof(GetAllInsurancePolicies), policy.PolicyNo);
            }
            return BadRequest("Insurance policy cannot be created");
        }

        [HttpPut("UpdatePolicy")]
        public IActionResult UpdatePolicy([FromBody] InsurancePolicyDTO policyDTO)
        {
            var newPolicy = ConvertToInsurancePolicy(policyDTO);
            newPolicy.PolicyNo = policyDTO.PolicyNo; // Assuming you have a PolicyId property in InsurancePolicyDTO
            var updatedPolicy = _insurancePolicyService.Update(newPolicy);
            return Ok(updatedPolicy.PolicyNo);
        }
        [HttpDelete("DeleteInsurancePolicy/{id}")]
        public IActionResult DeleteInsurancePolicyById(int id)
        {
            var isRemoved = _insurancePolicyService.Delete(id);

            if (isRemoved)
            {
                return Ok("Insurance Policy Removed Successfully");
            }

            return NotFound("Insurance Policy not found");
        }

        // Add other actions as needed

        private InsurancePolicy ConvertToInsurancePolicy(InsurancePolicyDTO policyDTO)
        {
            return new InsurancePolicy
            {
                PolicyNo = policyDTO.PolicyNo,
                IssueDate = policyDTO.IssueDate,
                MaturityDate = policyDTO.MaturityDate,
                PremiumType = policyDTO.PremiumType,
                PremiumAmount = policyDTO.PremiumAmount,
                SumAssured = policyDTO.SumAssured,
                Status = policyDTO.Status,
                PlanId = policyDTO.PlanId,
                CustomerId = policyDTO.CustomerId,
                PocilyId = policyDTO.PocilyId,
                
                
                // Add other property mappings as needed
            };
        }
        private InsurancePolicyDTO ConvertToInsurancePolicyDTO(InsurancePolicy policy)
        {
            return new InsurancePolicyDTO
            {
                PolicyNo = policy.PolicyNo,
                IssueDate = policy.IssueDate,
                MaturityDate = policy.MaturityDate,
                PremiumType = policy.PremiumType,
                PremiumAmount = policy.PremiumAmount,
                SumAssured = policy.SumAssured,
                Status = policy.Status,
                PlanId = policy.PlanId,
                CustomerId = policy.CustomerId,
                PocilyId = policy.PocilyId
                // Add other property mappings as needed
            };
        }
    }
}
