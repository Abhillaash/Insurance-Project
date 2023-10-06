using InsuranceProject.DTOs;
using InsuranceProject.Model.Actors;
using InsuranceProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("GetCustomer/{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDTO = ConvertToCustomerDTO(customer);
            return Ok(customerDTO);
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            var newCustomer = ConvertToCustomer(customerDTO);
            var customer = _customerService.Add(newCustomer);
            if (customer != null)
            {
                return CreatedAtAction(nameof(GetCustomers), customer.CustomerId);
            }
            return BadRequest("Customer cannot be created");
        }

        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] CustomerDTO customerDTO)
        {
            var newCustomer = ConvertToCustomer(customerDTO);
            newCustomer.CustomerId = customerDTO.CustomerId;
            var customer = _customerService.Update(newCustomer);
            return Ok(customer.CustomerId);
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomerById(int id)
        {
            var isRemoved = _customerService.Delete(id);

            if (isRemoved)
            {
                return Ok("Customer Removed Successfully");
            }

            return NotFound("Customer not found");
        }

        private Customer ConvertToCustomer(CustomerDTO customerDTO)
        {
            return new Customer
            {
                CustomerId = customerDTO.CustomerId,
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                EmailId = customerDTO.EmailId,
                MobileNo = customerDTO.MobileNo,
                State = customerDTO.State,
                City = customerDTO.City,
                Nominee = customerDTO.Nominee,
                NomineeRelation = customerDTO.NomineeRelation,
                Status = customerDTO.Status
                // Add other property mappings as needed
            };
        }
        private CustomerDTO ConvertToCustomerDTO(Customer customer)
        {
            return new CustomerDTO
            {
                CustomerId = customer.CustomerId, // Assuming CustomerId corresponds to UserId in the DTO
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailId = customer.EmailId, // Map Email property to EmailId
                MobileNo = customer.MobileNo, // Map MobileNo property
                State = customer.State, // Map State property
                City = customer.City, // Map City property
                Nominee = customer.Nominee, // Map Nominee property
                NomineeRelation = customer.NomineeRelation, // Map NomineeRelation property
                Status = customer.Status // Map IsActive property to Status
                                       // Add other property mappings as needed
            };
        }
    }
}
