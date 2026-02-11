using Microsoft.AspNetCore.Mvc;
using RatingsApp.Models;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentTerms payment)
        {
            await _service.AddAsync(payment);
            return Ok("Payment Terms Saved");
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }
    }
}
