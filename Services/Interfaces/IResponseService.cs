using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Services.Interfaces
{
    public interface IResponseService
    {
        Task AddAsync(ResponsePerformance response);
        Task<ResponsePerformance?> GetBySupplierIdAsync(int supplierId);
    }
}
