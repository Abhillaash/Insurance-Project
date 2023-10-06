using InsuranceProject.Model.Actors;
using InsuranceProject.Service;
using InsuranceProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("GetRole/{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            var roleDTO = ConvertToRoleDTO(role);
            return Ok(roleDTO);
        }

        [HttpPost("AddRole")]
        public IActionResult AddRole([FromBody] RoleDTO roleDTO)
        {
            var newRole = ConvertToRole(roleDTO);
            var role = _roleService.AddRole(newRole);
            if (role != null)
            {
                return CreatedAtAction(nameof(GetAllRoles), role.RoleId);
            }
            return BadRequest("Role cannot be created");
        }

        [HttpPut("UpdateRole")]
        public IActionResult UpdateRole([FromBody] RoleDTO roleDTO)
        {
            var newRole = ConvertToRole(roleDTO);
            newRole.RoleId = roleDTO.RoleId; // Assuming you have a RoleId property in RoleDTO
            var updatedRole = _roleService.UpdateRole(newRole);
            return Ok(updatedRole.RoleId);
        }

        // Add other actions as needed
        [HttpDelete("DeleteRole/{id}")]
        public IActionResult DeleteRoleById(int id)
        {
            var isRemoved = _roleService.DeleteRole(id);

            if (isRemoved)
            {
                return Ok("Role Removed Successfully");
            }

            return NotFound("Role not found");
        }

        private RoleDTO ConvertToRoleDTO(Role role)
        {
            return new RoleDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Status = role.Status,
                
                
            };
        }

        private Role ConvertToRole(RoleDTO roleDTO)
        {
            return new Role
            {
                RoleId = roleDTO.RoleId,
                RoleName = roleDTO.RoleName,
                Status = roleDTO.Status,
                // Add other property mappings as needed
            };
        }
    }
}
