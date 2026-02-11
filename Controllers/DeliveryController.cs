using Microsoft.AspNetCore.Mvc;
using RatingsApp.Models;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/delivery")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _service;

        public DeliveryController(IDeliveryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DeliveryPerformance delivery)
        {
            await _service.AddAsync(delivery);
            return Ok("Delivery Performance Saved");
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }
    }
}
