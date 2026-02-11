using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Interfaces
{
    public interface IQualityRepository
    {
        Task AddAsync(QualityPerformance quality);
        Task<QualityPerformance?> GetBySupplierIdAsync(int supplierId);
    }
}
