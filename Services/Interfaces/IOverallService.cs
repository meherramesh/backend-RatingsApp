using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Services.Interfaces
{
    public interface IOverallService
    {
        Task AddAsync(OverallRating overall);
        Task<OverallRating?> GetBySupplierIdAsync(int supplierId);
    }
}
