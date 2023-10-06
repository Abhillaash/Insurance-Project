using InsuranceProject.Model.Holdings;
using InsuranceProject.Service;

using InsuranceProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePlanController : ControllerBase
    {
        private readonly IInsurancePlanService _insurancePlanService;

        public InsurancePlanController(IInsurancePlanService insurancePlanService)
        {
            _insurancePlanService = insurancePlanService;
        }

        [HttpGet("GetAllPlans")]
        public IActionResult GetAllPlans()
        {
            var plans = _insurancePlanService.GetAllInsurancePlans();
            return Ok(plans);
        }

        [HttpGet("GetPlan/{id}")]
        public IActionResult GetPlan(int id)
        {
            var plan = _insurancePlanService.GetInsurancePlanById(id);
            if (plan == null)
            {
                return NotFound();
            }
            var planDTO = ConvertToInsurancePlanDTO(plan);
            return Ok(planDTO);
        }

        [HttpPost("AddPlan")]
        public IActionResult AddPlan([FromBody] InsurancePlanDTO planDTO)
        {
            var newPlan = ConvertToInsurancePlan(planDTO);
            var plan = _insurancePlanService.AddInsurancePlan(newPlan);
            if (plan != null)
            {
                return CreatedAtAction(nameof(GetAllPlans), plan.PlanId);
            }
            return BadRequest("Insurance plan cannot be created");
        }

        [HttpPut("UpdatePlan")]
        public IActionResult UpdatePlan([FromBody] InsurancePlanDTO planDTO)
        {
            var newPlan = ConvertToInsurancePlan(planDTO);
            newPlan.PlanId = planDTO.PlanId; // Assuming you have a PlanId property in InsurancePlanDTO
            var updatedPlan = _insurancePlanService.UpdateInsurancePlan(newPlan);
            return Ok(updatedPlan.PlanId);
        }
        [HttpDelete("DeleteInsurancePlan/{id}")]
        public IActionResult DeleteInsurancePlanById(int id)
        {
            var isRemoved = _insurancePlanService.DeleteInsurancePlan(id);

            if (isRemoved)
            {
                return Ok("Insurance Plan Removed Successfully");
            }

            return NotFound("Insurance Plan not found");
        }

        // Add other actions as needed

        private InsurancePlanDTO ConvertToInsurancePlanDTO(InsurancePlan plan)
        {
            return new InsurancePlanDTO
            {
                PlanId = plan.PlanId,
                PlanName = plan.PlanName,
                Status = plan.Status,
                // Add other property mappings as needed
            };
        }

        private InsurancePlan ConvertToInsurancePlan(InsurancePlanDTO planDTO)
        {
            return new InsurancePlan
            {
                PlanId = planDTO.PlanId,
                PlanName = planDTO.PlanName,
                Status = planDTO.Status,
                // Add other property mappings as needed
            };
        }

    }
}
