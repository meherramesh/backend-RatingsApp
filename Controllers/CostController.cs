using Microsoft.AspNetCore.Mvc;
using RatingsApp.Models;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/cost")]
    public class CostController : ControllerBase
    {
        private readonly ICostService _service;

        public CostController(ICostService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CostReduction cost)
        {
            await _service.AddAsync(cost);
            return Ok("Cost Reduction Saved");
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }
    }
}
