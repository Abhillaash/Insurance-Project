using InsuranceProject.Model.Holdings;
using InsuranceProject.Service;
using InsuranceProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceSchemeController : ControllerBase
    {
        private readonly IInsuranceSchemeService _insuranceSchemeService;

        public InsuranceSchemeController(IInsuranceSchemeService insuranceSchemeService)
        {
            _insuranceSchemeService = insuranceSchemeService;
        }

        //[HttpGet("GetAllSchemes")]
        //public IActionResult GetAllSchemes()
        //{
        //    var schemes = _insuranceSchemeService.GetAllInsuranceSchemes();
        //    return Ok(schemes);
        //}
        [HttpGet("GetAllInsuranceSchemes")]
        public IActionResult GetAllInsuranceSchemes()
        {
            var insuranceSchemes = _insuranceSchemeService.GetAllInsuranceSchemes();

            var insuranceSchemeDTOs = new List<InsuranceSchemeDTO>();
            foreach (var scheme in insuranceSchemes)
            {
                var schemeDTO = ConvertToInsuranceSchemeDTO(scheme);
                insuranceSchemeDTOs.Add(schemeDTO);
            }

            return Ok(insuranceSchemeDTOs);
        }


        [HttpGet("GetScheme/{id}")]
        public IActionResult GetScheme(int id)
        {
            var scheme = _insuranceSchemeService.GetInsuranceSchemeById(id);
            if (scheme == null)
            {
                return NotFound();
            }
            var schemeDTO = ConvertToInsuranceSchemeDTO(scheme);
            return Ok(schemeDTO);
        }

        [HttpPost("AddScheme")]
        public IActionResult AddScheme([FromBody] InsuranceSchemeDTO schemeDTO)
        {
            var newScheme = ConvertToInsuranceScheme(schemeDTO);
            var scheme = _insuranceSchemeService.AddInsuranceScheme(newScheme);
            if (scheme != null)
            {
                return CreatedAtAction(nameof(GetAllInsuranceSchemes), scheme.SchemeId);
            }
            return BadRequest("Insurance scheme cannot be created");
        }

        [HttpPut("UpdateScheme")]
        public IActionResult UpdateScheme([FromBody] InsuranceSchemeDTO schemeDTO)
        {
            var newScheme = ConvertToInsuranceScheme(schemeDTO);
            newScheme.SchemeId = schemeDTO.SchemeId; // Assuming you have a SchemeId property in InsuranceSchemeDTO
            var updatedScheme = _insuranceSchemeService.UpdateInsuranceScheme(newScheme);
            return Ok(updatedScheme.SchemeId);
        }
        [HttpDelete("DeleteInsuranceScheme/{id}")]
        public IActionResult DeleteInsuranceSchemeById(int id)
        {
            var isRemoved = _insuranceSchemeService.DeleteInsuranceScheme(id);

            if (isRemoved)
            {
                return Ok("Insurance Scheme Removed Successfully");
            }

            return NotFound("Insurance Scheme not found");
        }

        // Add other actions as needed

        private InsuranceSchemeDTO ConvertToInsuranceSchemeDTO(InsuranceScheme scheme)
        {
            return new InsuranceSchemeDTO
            {
                SchemeId = scheme.SchemeId,
                SchemeName = scheme.SchemeName,
                Status = scheme.Status,
                PlanId = scheme.PlanId,
                // Add other property mappings as needed
            };
        }


        private InsuranceScheme ConvertToInsuranceScheme(InsuranceSchemeDTO schemeDTO)
        {
            return new InsuranceScheme
            {
                SchemeId = schemeDTO.SchemeId,
                SchemeName = schemeDTO.SchemeName,
                Status = schemeDTO.Status,
                PlanId = schemeDTO.PlanId,
                // Add other property mappings as needed
            };
        }
    }
}
