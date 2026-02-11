using Microsoft.AspNetCore.Mvc;
using RatingsApp.Models;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetSuppliersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetSupplierAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            await _service.AddSupplierAsync(supplier);
            return Ok("Supplier rating added successfully");
        }
    }
}
