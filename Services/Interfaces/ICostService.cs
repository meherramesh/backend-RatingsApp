using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;
    
namespace RatingsApp.Services.Interfaces
{
    public interface ICostService
    {
        Task AddAsync(CostReduction cost);
        Task<CostReduction?> GetBySupplierIdAsync(int supplierId);
    }
}
