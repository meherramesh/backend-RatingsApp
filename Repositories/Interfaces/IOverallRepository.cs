using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Interfaces
{
    public interface IOverallRepository
    {
        Task AddAsync(OverallRating overall);
        Task<OverallRating?> GetBySupplierIdAsync(int supplierId);
    }
}
