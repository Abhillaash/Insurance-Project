﻿using InsuranceProject.DTOs;
using InsuranceProject.Model.Actors;
using InsuranceProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = ConvertToEmployeeDTO(employee);
            return Ok(employeeDTO);
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var newEmployee = ConvertToEmployee(employeeDTO);
            var employee = _employeeService.Add(newEmployee);
            if (employee != null)
            {
                return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmployeeId });
            }

            return BadRequest("Employee cannot be created");
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var newEmployee = ConvertToEmployee(employeeDTO);
            newEmployee.EmployeeId = employeeDTO.EmployeeId;

            var updatedEmployee = _employeeService.Update(newEmployee);
            if (updatedEmployee != null)
            {
                return Ok(updatedEmployee.EmployeeId);
            }

            return NotFound("Employee not found");
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
                EmployeeId = employee.UserId, // Assuming EmployeeId corresponds to UserId in the DTO
                EmployeeFirstName = employee.FirstName,
                EmployeeLastName = employee.LastName,
                MobileNo = employee.MobileNo, // Map MobileNo property
                EmailId = employee.EmailId, // Map EmailId property
                Salary = employee.Salary, // Map Salary property
                UserId = employee.UserId, // Set UserId if needed
                Status = employee.IsActive // Map IsActive property to Status
                                       // Add other property mappings as needed
            };
        }
    }
}
