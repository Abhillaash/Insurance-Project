using InsuranceProject.DTOs;
using InsuranceProject.Model.Actors;
using InsuranceProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet("GetAllAgents")]
        public IActionResult GetAgents()
        {
            var agents = _agentService.GetAll();
            var agentDTOs = new List<AgentDTO>();
            foreach (var agent in agents)
            {
                var agentDTO = ConvertToAgentDTO(agent); // Implement this method to convert Agent to AgentDTO
                agentDTOs.Add(agentDTO);
            }
            return Ok(agentDTOs);
        }

        [HttpGet("GetAgent/{id}")]
        public IActionResult GetAgent(int id)
        {
            var agent = _agentService.GetById(id);
            if (agent == null)
            {
                return NotFound();
            }
            var agentDTO = ConvertToAgentDTO(agent); // Implement this method to convert Agent to AgentDTO
            return Ok(agentDTO);
        }

        [HttpPost("AddAgent")]
        public IActionResult AddAgent([FromBody] AgentDTO agentDTO)
        {
            var newAgent = ConvertToAgent(agentDTO); // Implement this method to convert AgentDTO to Agent
            var agent = _agentService.Add(newAgent);
            if (agent != null)
            {
                return CreatedAtAction(nameof(GetAgents), agent.AgentId);
            }
            return BadRequest("Agent cannot be created");
        }

        [HttpPut("UpdateAgent")]
        public IActionResult UpdateAgent([FromBody] AgentDTO agentDTO)
        {
            var newAgent = ConvertToAgent(agentDTO); // Implement this method to convert AgentDTO to Agent
            newAgent.AgentId = agentDTO.AgentId;
            var agent = _agentService.Update(newAgent);
            if (agent != null)
            {
                return Ok(agent.AgentId);
            }
            return NotFound();
        }

        // Add other agent-related endpoints as needed

        
        private Agent ConvertToAgent(AgentDTO agentDTO)
        {
            return new Agent
            {
                AgentId = agentDTO.AgentId,
                AgentFirstName = agentDTO.AgentFirstName,
                AgentLastName = agentDTO.AgentLastName,
                Qualification = agentDTO.Qualification,
                Email = agentDTO.Email,
                MobileNo = agentDTO.MobileNo,
                UserId = agentDTO.UserId,
                CommissionEarned = agentDTO.CommissionEarned,
                Status = agentDTO.Status
                // Add other property mappings as needed
            };
        }
        private AgentDTO ConvertToAgentDTO(Agent agent)
        {
            return new AgentDTO
            {
                AgentId = agent.UserId, // Assuming AgentId corresponds to UserId in the DTO
                AgentFirstName = agent.FirstName,
                AgentLastName = agent.LastName,
                Qualification = agent.Qualification, // Map Qualification property
                Email = agent.Email, // Map Email property
                MobileNo = agent.MobileNo, // Map MobileNo property
                UserId = agent.UserId, // Set UserId if needed
                CommissionEarned = agent.CommissionEarned, // Map CommissionEarned property
                Status = agent.IsActive // Map IsActive property to Status
                                       // Add other property mappings as needed
            };
        }

    }
}

