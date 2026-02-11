using Microsoft.AspNetCore.Mvc;
using RatingsApp.Models;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/quality")]
    public class QualityController : ControllerBase
    {
        private readonly IQualityService _service;

        public QualityController(IQualityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(QualityPerformance quality)
        {
            await _service.AddAsync(quality);
            return Ok("Quality Performance Saved");
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }
    }
}
