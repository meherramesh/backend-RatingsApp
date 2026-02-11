using Microsoft.AspNetCore.Mvc;
using RatingsApp.Models;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/response")]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _service;

        public ResponseController(IResponseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ResponsePerformance response)
        {
            await _service.AddAsync(response);
            return Ok("Response Saved");
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }
    }
}
