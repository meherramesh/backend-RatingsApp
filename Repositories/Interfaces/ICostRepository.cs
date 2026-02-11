using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Interfaces
{
    public interface ICostRepository
    {
        Task AddAsync(CostReduction cost);
        Task<CostReduction?> GetBySupplierIdAsync(int supplierId);
    }
}
