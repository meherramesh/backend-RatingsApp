using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Interfaces
{
    public interface IResponseRepository
    {
        Task AddAsync(ResponsePerformance response);
        Task<ResponsePerformance?> GetBySupplierIdAsync(int supplierId);
    }
}
