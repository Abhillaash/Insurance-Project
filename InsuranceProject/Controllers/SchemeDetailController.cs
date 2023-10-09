using InsuranceProject.Model.Holdings;
using InsuranceProject.Service;

using InsuranceProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemeDetailController : ControllerBase
    {
        private readonly ISchemeDetailsService _schemeDetailsService;

        public SchemeDetailController(ISchemeDetailsService schemeDetailsService)
        {
            _schemeDetailsService = schemeDetailsService;
        }

        //[HttpGet("GetAllSchemeDetails")]
        //public IActionResult GetAllSchemeDetails()
        //{
        //    var schemeDetails = _schemeDetailsService.GetAll();
        //    return Ok(schemeDetails);
        //}

        [HttpGet("GetAllSchemeDetails")]
        public IActionResult GetAllSchemeDetails()
        {
            var schemeDetails = _schemeDetailsService.GetAll();

            var schemeDetailDTOs = new List<SchemeDetailsDTO>();
            foreach (var schemeDetail in schemeDetails)
            {
                var schemeDetailDTO = ConvertToSchemeDetailsDTO(schemeDetail);
                schemeDetailDTOs.Add(schemeDetailDTO);
            }

            return Ok(schemeDetailDTOs);
        }


        [HttpGet("GetSchemeDetails/{id}")]
        public IActionResult GetSchemeDetails(int id)
        {
            var schemeDetails = _schemeDetailsService.GetById(id);
            if (schemeDetails == null)
            {
                return NotFound();
            }
            var schemeDetailsDTO = ConvertToSchemeDetailsDTO(schemeDetails);
            return Ok(schemeDetailsDTO);
        }

        [HttpPost("AddSchemeDetails")]
        public IActionResult AddSchemeDetails([FromBody] SchemeDetailsDTO schemeDetailsDTO)
        {
            var newSchemeDetails = ConvertToSchemeDetails(schemeDetailsDTO);
            var schemeDetails = _schemeDetailsService.Add(newSchemeDetails);
            if (schemeDetails != null)
            {
                return CreatedAtAction(nameof(GetAllSchemeDetails), schemeDetails.DetailId);
            }
            return BadRequest("Scheme details cannot be created");
        }

        [HttpPut("UpdateSchemeDetails")]
        public IActionResult UpdateSchemeDetails([FromBody] SchemeDetailsDTO schemeDetailsDTO)
        {
            var newSchemeDetails = ConvertToSchemeDetails(schemeDetailsDTO);
            newSchemeDetails.DetailId = schemeDetailsDTO.DetailId; // Assuming you have a SchemeDetailsId property in SchemeDetailsDTO
            var updatedSchemeDetails = _schemeDetailsService.Update(newSchemeDetails);
            return Ok(updatedSchemeDetails.DetailId);
        }
        [HttpDelete("DeleteSchemeDetails/{id}")]
        public IActionResult DeleteSchemeDetailsById(int id)
        {
            var isRemoved = _schemeDetailsService.Delete(id);

            if (isRemoved)
            {
                return Ok("Scheme Details Removed Successfully");
            }

            return NotFound("Scheme Details not found");
        }

        // Add other actions as needed

        private SchemeDetailsDTO ConvertToSchemeDetailsDTO(SchemeDetails schemeDetails)
        {
            return new SchemeDetailsDTO
            {
                DetailId = schemeDetails.DetailId,
                SchemeImage = schemeDetails.SchemeImage,
                Description = schemeDetails.Description,
                MinAmount = schemeDetails.MinAmount,
                MaxAmount = schemeDetails.MaxAmount,
                MinAge = schemeDetails.MinAge,
                MaxAge = schemeDetails.MaxAge,
                ProfitRatio = schemeDetails.ProfitRatio,
                RegistrationCommRatio = schemeDetails.RegistrationCommRatio,
                InstallmentCommRatio = schemeDetails.InstallmentCommRatio,
                MinInvestTime = schemeDetails.MinInvestTime,
                MaxInvestTime = schemeDetails.MaxInvestTime,
                Status = schemeDetails.Status,
                SchemeId=schemeDetails.SchemeId
                // Add other property mappings as needed
            };
        }

        private SchemeDetails ConvertToSchemeDetails(SchemeDetailsDTO schemeDetailsDTO)
        {
            return new SchemeDetails
            {
                DetailId = schemeDetailsDTO.DetailId,
                SchemeImage = schemeDetailsDTO.SchemeImage,
                Description = schemeDetailsDTO.Description,
                MinAmount = schemeDetailsDTO.MinAmount,
                MaxAmount = schemeDetailsDTO.MaxAmount,
                MinAge = schemeDetailsDTO.MinAge,
                MaxAge = schemeDetailsDTO.MaxAge,
                ProfitRatio = schemeDetailsDTO.ProfitRatio,
                RegistrationCommRatio = schemeDetailsDTO.RegistrationCommRatio,
                InstallmentCommRatio = schemeDetailsDTO.InstallmentCommRatio,
                MinInvestTime = schemeDetailsDTO.MinInvestTime,
                MaxInvestTime = schemeDetailsDTO.MaxInvestTime,
                Status = schemeDetailsDTO.Status,
                SchemeId = schemeDetailsDTO.SchemeId
                // Add other property mappings as needed
            };
        }
    }
}
