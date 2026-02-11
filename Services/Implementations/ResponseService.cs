using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using RatingsApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Services.Implementations
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _repository;

        public ResponseService(IResponseRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(ResponsePerformance response)
        {
            await _repository.AddAsync(response);
        }

        public async Task<ResponsePerformance?> GetBySupplierIdAsync(int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }
    }
}
