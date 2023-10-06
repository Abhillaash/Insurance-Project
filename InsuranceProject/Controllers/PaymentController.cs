using InsuranceProject.Model.Holdings;
using InsuranceProject.Service;
using InsuranceProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("GetAllPayments")]
        public IActionResult GetAllPayments()
        {
            var payments = _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("GetPayment/{id}")]
        public IActionResult GetPayment(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDTO = ConvertToPaymentDTO(payment);
            return Ok(paymentDTO);
        }

        [HttpPost("AddPayment")]
        public IActionResult AddPayment([FromBody] PaymentDTO paymentDTO)
        {
            var newPayment = ConvertToPayment(paymentDTO);
            var payment = _paymentService.AddPayment(newPayment);
            if (payment != null)
            {
                return CreatedAtAction(nameof(GetAllPayments), payment.PaymentId);
            }
            return BadRequest("Payment cannot be created");
        }

        //[HttpPut("UpdatePayment")]
        //public IActionResult UpdatePayment([FromBody] PaymentDTO paymentDTO)
        //{
        //    var newPayment = ConvertToPayment(paymentDTO);
        //    newPayment.PaymentId = paymentDTO.PaymentId; // Assuming you have a PaymentId property in PaymentDTO
        //    var updatedPayment = _paymentService.UpdatePayment(newPayment);
        //    return Ok(updatedPayment.PaymentId);
        //}

        // Add other actions as needed
        //[HttpDelete("DeletePayment/{id}")]
        //public IActionResult DeletePaymentById(int id)
        //{
        //    var isRemoved = _paymentService.Delete(id);

        //    if (isRemoved)
        //    {
        //        return Ok("Payment Removed Successfully");
        //    }

        //    return NotFound("Payment not found");
        //}

        private PaymentDTO ConvertToPaymentDTO(Payment payment)
        {
            return new PaymentDTO
            {
                PaymentId = payment.PaymentId,
                PaymentType = payment.PaymentType,
                Amount = payment.Amount,
                Date = payment.Date,
                Tax = payment.Tax,
                TotalPayment = payment.TotalPayment
            };
        }

        private Payment ConvertToPayment(PaymentDTO paymentDTO)
        {
            return new Payment
            {
                PaymentId = paymentDTO.PaymentId,
                PaymentType = paymentDTO.PaymentType,
                Amount = paymentDTO.Amount,
                Date = paymentDTO.Date,
                Tax = paymentDTO.Tax,
                TotalPayment = paymentDTO.TotalPayment,
                // Add other property mappings as needed
            };
        }
    }
}
