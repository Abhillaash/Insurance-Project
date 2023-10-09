using InsuranceProject.Model.Actors;
using InsuranceProject.Service;
using InsuranceProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("GetAllUsers")]
        //public IActionResult GetUsers()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();

            var userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                var userDTO = ConvertToUserDTO(user);
                userDTOs.Add(userDTO);
            }

            return Ok(userDTOs);
        }


        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = ConvertToUserDTO(user);
            return Ok(userDTO);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] UserDTO userDTO)
        {
            var newUser = ConvertToUser(userDTO);
            var user = _userService.Add(newUser);
            if (user != null)
            {
                return CreatedAtAction(nameof(GetAllUsers), new { id = user.UserId });
            }
            return BadRequest("User cannot be created");
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserDTO userDTO)
        {
            var newUser = ConvertToUser(userDTO);
            newUser.UserId = userDTO.UserId;

            var updatedUser = _userService.Update(newUser);
            return Ok(updatedUser.UserId);
        }
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var isRemoved = _userService.Delete(id);

            if (isRemoved)
            {
                return Ok("User Removed Successfully");
            }

            return NotFound("User not found");
        }

        private User ConvertToUser(UserDTO userDTO)
        {
            return new User
            {
                UserId = userDTO.UserId,
                Username = userDTO.Username,
                Password = userDTO.Password,
                Status = userDTO.Status,
                RoleId = userDTO.RoleId,
                
                // Add other property mappings as needed
            };
        }

        private UserDTO ConvertToUserDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                Status= user.Status,
                RoleId = user.RoleId,

                // Add other property mappings as needed
            };
        }

    }
}
