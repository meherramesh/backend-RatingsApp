using Microsoft.AspNetCore.Mvc;
using RatingsApp.Models;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/overall")]
    public class OverallController : ControllerBase
    {
        private readonly IOverallService _service;

        public OverallController(IOverallService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(OverallRating overall)
        {
            await _service.AddAsync(overall);
            return Ok("Overall Rating Saved");
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }
    }
}
