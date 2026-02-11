using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Services.Interfaces
{
    public interface IQualityService
    {
        Task AddAsync(QualityPerformance quality);
        Task<QualityPerformance?> GetBySupplierIdAsync(int supplierId);
    }
}
