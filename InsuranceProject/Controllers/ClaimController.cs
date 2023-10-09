using InsuranceProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InsuranceProject.DTOs;
using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet("GetAllClaims")]
        public IActionResult GetAllClaims()
        {
            var claims = _claimService.GetAllClaims();
            

            
            var claimDTOs = new List<ClaimDTO>();
            foreach (var claim in claims)
            {
                var claimDTO = ConvertToClaimDTO(claim); 
                claimDTOs.Add(claimDTO);
            }
            return Ok(claimDTOs);
        }

        [HttpGet("GetClaim/{id}")]
        public IActionResult GetClaim(int id)
        {
            var claim = _claimService.GetClaimById(id);
            if (claim == null)
            {
                return NotFound();
            }
            var claimDTO = ConvertToClaimDTO(claim);
            return Ok(claimDTO);
        }

        [HttpPost("AddClaim")]
        public IActionResult AddClaim([FromBody] ClaimDTO claimDTO)
        {
            var newClaim = ConvertToClaim(claimDTO);
            var claim = _claimService.AddClaim(newClaim);
            if (claim != null)
            {
                return CreatedAtAction(nameof(GetAllClaims), claim.ClaimId);
            }
            return BadRequest("Claim cannot be created");
        }

        [HttpPut("UpdateClaim")]
        public IActionResult UpdateClaim([FromBody] ClaimDTO claimDTO)
        {
            var newClaim = ConvertToClaim(claimDTO);
            newClaim.ClaimId = claimDTO.ClaimId; // Assuming you have a ClaimId property in ClaimDTO
            var updatedClaim = _claimService.UpdateClaim(newClaim);
            return Ok(updatedClaim.ClaimId);
        }

        [HttpDelete("DeleteClaim/{id}")]
        public IActionResult DeleteClaimById(int id)
        {
            var isRemoved = _claimService.DeleteClaim(id);

            if (isRemoved)
            {
                return Ok("Claim Removed Successfully");
            }

            return NotFound("Claim not found");
        }

        private ClaimDTO ConvertToClaimDTO(Claim claim)
        {
            return new ClaimDTO
            {
                ClaimId = claim.ClaimId,
                
                ClaimAmount = claim.ClaimAmount,
                BankAccountNumber = claim.BankAccountNumber,
                BankIFSCCode = claim.BankIFSCCode,
                PocilyId = claim.PocilyId,
                Status = claim.Status,
                // Add other property mappings as needed
            };
        }

        private Claim ConvertToClaim(ClaimDTO claimDTO)
        {
            return new Claim
            {
                ClaimId = claimDTO.ClaimId,
                
                ClaimAmount = claimDTO.ClaimAmount,
                BankAccountNumber = claimDTO.BankAccountNumber,
                BankIFSCCode = claimDTO.BankIFSCCode,
                Date = DateTime.Now,
                Status = claimDTO.Status,
                PocilyId = claimDTO.PocilyId,
                // Add other property mappings as needed
            };
        }
    }
}
