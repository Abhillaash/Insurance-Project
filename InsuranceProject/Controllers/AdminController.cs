using InsuranceProject.DTOs;
using InsuranceProject.Model.Actors;
using InsuranceProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        //// Manage City/State
        //[HttpGet("manage-city-state")]
        //public IActionResult ManageCityState()
        //{
        //    // Implement logic for managing city/state here
        //    return View();
        //}

        // Manage Tax and Insurance settings
        //[HttpGet("manage-tax-insurance")]
        //public IActionResult ManageTaxInsurance()
        //{
        //    // Implement logic for managing tax and insurance settings here
        //    return View();
        //}

        //// Add Employee
        //[HttpGet("add-employee")]
        //public IActionResult AddEmployee()
        //{
        //    // Implement logic for adding an employee here
        //    return View();
        //}

        //// Add Agent
        //[HttpGet("add-agent")]
        //public IActionResult AddAgent()
        //{
        //    // Implement logic for adding an agent here
        //    return View();
        //}

        //// Insurance Type Master
        //[HttpGet("insurance-type-master")]
        //public IActionResult InsuranceTypeMaster()
        //{
        //    // Implement logic for managing insurance types here
        //    return View();
        //}

        //// Insurance Plan Master
        //[HttpGet("insurance-plan-master")]
        //public IActionResult InsurancePlanMaster()
        //{
        //    // Implement logic for managing insurance plans here
        //    return View();
        //}

        //// Commission Settings
        //[HttpGet("commission-settings")]
        //public IActionResult CommissionSettings()
        //{
        //    // Implement logic for managing commission settings here
        //    return View();
        //}

        //// Withdrawal Approval
        //[HttpGet("withdrawal-approval")]
        //public IActionResult WithdrawalApproval()
        //{
        //    // Implement logic for managing withdrawal approvals here
        //    return View();
        //}

        //// Customer Report
        //[HttpGet("customer-report")]
        //public IActionResult CustomerReport()
        //{
        //    // Implement logic for generating customer reports here
        //    return View();
        //}

        //// Agent Report
        //[HttpGet("agent-report")]
        //public IActionResult AgentReport()
        //{
        //    // Implement logic for generating agent reports here
        //    return View();
        //}

        //// Agent Wise Commission Report
        //[HttpGet("agent-wise-commission-report")]
        //public IActionResult AgentWiseCommissionReport()
        //{
        //    // Implement logic for generating agent-wise commission reports here
        //    return View();
        //}

        //// Policy Payment Report
        //[HttpGet("policy-payment-report")]
        //public IActionResult PolicyPaymentReport()
        //{
        //    // Implement logic for generating policy payment reports here
        //    return View();
        //}

        //// Withdrawal Report
        //[HttpGet("withdrawal-report")]
        //public IActionResult WithdrawalReport()
        //{
        //    // Implement logic for generating withdrawal reports here
        //    return View();
        //}

        //// Commission Withdrawal Report
        //[HttpGet("commission-withdrawal-report")]
        //public IActionResult CommissionWithdrawalReport()
        //{
        //    // Implement logic for generating commission withdrawal reports here
        //    return View();
        //}

        //// Insurance Account Report
        //[HttpGet("insurance-account-report")]
        //public IActionResult InsuranceAccountReport()
        //{
        //    // Implement logic for generating insurance account reports here
        //    return View();
        //}

        //// Transaction Report
        //[HttpGet("transaction-report")]
        //public IActionResult TransactionReport()
        //{
        //    // Implement logic for generating transaction reports here
        //    return View();
        //}
        //[HttpGet("GetAllEmployees")]
        //public IActionResult GetEmployees()
        //{
        //    var employees = _adminService.GetAllEmployees();
        //    return Ok(employees);
        //}
        //[HttpGet("GetEmployee/{id}")]
        //public IActionResult GetEmployee(int EmployeeId,int AdminId)
        //{
        //    var employee = _adminService.GetByIdEmployee( EmployeeId,  AdminId);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    var employeeDTO = ConvertToEmployeeDTO(employee);
        //    return Ok(employeeDTO);
        //}
        //[HttpPost("AddEmployee")]
        //public IActionResult AddEmployee([FromBody] EmployeeDTO employeeDTO)
        //{
        //    var newEmployee = ConvertToEmployee(employeeDTO); // Implement ConvertToEmployee method
        //    var employee = _adminService.AddEmployee(newEmployee); // Assuming you have an EmployeeService
        //    if (employee != null)
        //    {
        //        return CreatedAtAction(nameof(GetEmployees), employee.EmployeeId);
        //    }

        //    return BadRequest("Employee cannot be created");
        //}

        [HttpGet("GetAllAdmin")]
        public async Task<IActionResult> GetAdmins()
        {
            //string innerTables = "Contacts";
            //string innerMostTables = "ContactDetails";
            var admins = _adminService.GetAll();
            return Ok(admins);

        }

        [HttpGet("GetAdmin/{id}")]
        public IActionResult GetAdmin(int id)
        {
            var admin = _adminService.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }
            var adminDTO = ConvertToAdminDTO(admin);
            return Ok(adminDTO);
        }

        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin([FromBody] AdminDTO adminDTO)
        {
            var newAdmin = ConvertToAdmin(adminDTO);
            var admin = _adminService.Add(newAdmin);
            if (admin != null)
            {
                return CreatedAtAction(nameof(GetAdmins), admin.AdminId);
            }

            return BadRequest("User cannot be created");

        }

        [HttpPut("UpdateAdmin")]
        public IActionResult UpdateAdmin([FromBody] AdminDTO adminDTO)
        {
            var newAdmin = ConvertToAdmin(adminDTO);
            newAdmin.AdminId = adminDTO.AdminId;

            var user = _adminService.Update(newAdmin);
            return Ok(user.AdminId);






        }

        //[HttpDelete("DeleteAdmin/{id}")]
        //public IActionResult DeleteAdminById(int id)
        //{
        //    var isRemoved = _adminService.Delete(id);

        //    if (isRemoved)
        //    {
        //        return Ok("Agent Removed Successfully");
        //    }

        //    return NotFound("Agent not found");
        //}






        //[HttpGet("GetAllUsers")]
        //public IActionResult GetUsers()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);

        //}
        //[HttpGet("GetUser/{id}")]
        //public IActionResult GetUser(int id)
        //{
        //    var user = _userService.GetById(id);
        //    if (user == null)
        //    {
        //        return NotFound(); 
        //    }
        //    var userDTO = ConvertToUserDTO(user);
        //    return Ok(userDTO);
        //}

        //[HttpPost("AddUser")]
        //public IActionResult AddUser([FromBody]UserDTO userDTO)
        //{
        //    var newUser = ConvertToUser(userDTO);
        //    var user = _userService.Add(newUser);
        //    if (user != null)
        //    {
        //        return CreatedAtAction(nameof(GetUsers), user.UserId);
        //    }

        //    return BadRequest("User cannot be created");

        //}

        //[HttpPut("UpdateUser")]
        //public IActionResult UpdateUser([FromBody]UserDTO userDTO)
        //{
        //    var newUser = ConvertToUser(userDTO);
        //    newUser.UserId = userDTO.UserId;

        //    var user = _userService.Update(newUser);
        //    return Ok(user.UserId);






        //}

        //[HttpDelete("DeleteUser/{id}")]
        //public IActionResult DeleteUserById(int id)
        //{

        //        var isRemoved = _userService.Delete(id);
        //        return Ok("Removed Successfully");



        private AdminDTO ConvertToAdminDTO(Admin admin)
        {
            return new AdminDTO
            {
                AdminId = admin.AdminId, // Assuming AdminId corresponds to UserId in the DTO
                AdminFirstName = admin.AdminFirstName,
                AdminLastName = admin.AdminLastName,
                UserId = admin.UserId, // Set UserId if needed
                                      // Map other properties as needed
            };
        }
        private Admin ConvertToAdmin(AdminDTO adminDTO)
        {
            return new Admin
            {
                AdminId = adminDTO.AdminId,
                AdminFirstName = adminDTO.AdminFirstName,
                AdminLastName = adminDTO.AdminLastName,
                UserId = adminDTO.UserId
                // Add other property mappings as needed
            };
        }
        private Employee ConvertToEmployee(EmployeeDTO employeeDTO)
        {
            return new Employee
            {
                EmployeeId = employeeDTO.EmployeeId,
                EmployeeFirstName = employeeDTO.EmployeeFirstName,
                EmployeeLastName = employeeDTO.EmployeeLastName,
                MobileNo = employeeDTO.MobileNo,
                EmailId = employeeDTO.EmailId,
                Salary = employeeDTO.Salary,
                UserId = employeeDTO.UserId,
                Status = employeeDTO.Status
                // Add other property mappings as needed
            };
        }
        private EmployeeDTO ConvertToEmployeeDTO(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId, // Assuming EmployeeId corresponds to UserId in the DTO
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName,
                MobileNo = employee.MobileNo, // Map MobileNo property
                EmailId = employee.EmailId, // Map EmailId property
                Salary = employee.Salary, // Map Salary property
                UserId = employee.UserId, // Set UserId if needed
                Status = employee.Status // Map IsActive property to Status
                                         // Add other property mappings as needed
            };
        }

        //}
        //private AdminDTO ConvertToUserDTO(User user)
        //{
        //    int count = user.Contacts != null ? user.Contacts.Count() : 0;
        //    return new UserDTO()
        //    {
        //        UserId = user.UserId,

        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        IsActive = user.IsActive,
        //        IsAdmin = user.IsAdmin,
        //        CountContact = count,

        //    };

        //}
        //private User ConvertToUser(UserDTO userDTO)
        //{

        //    return new User()
        //    {
        //        UserId = userDTO.UserId,

        //        FirstName = userDTO.FirstName,
        //        LastName = userDTO.LastName,
        //        IsActive = userDTO.IsActive,
        //        IsAdmin = userDTO.IsAdmin,
        //        Contacts = new List<Contact>()

        //    };

        //}
    }
}

//using Microsoft.AspNetCore.Mvc;
//using InsuranceProject.Models; // Import your model classes
//using InsuranceProject.Services; // Import your services

//namespace InsuranceProject.Controllers
//{
//    [Route("admin")]
//    public class AdminController : Controller
//    {
//        private readonly IAdminService _adminService;

        
//    }
//}
