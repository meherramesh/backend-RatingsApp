using RatingsApp.Data;
using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Implementations
{
    public class OverallRepository : IOverallRepository
    {
        private readonly AppDbContext _context;

        public OverallRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OverallRating overall)
        {
            _context.OverallRatings.Add(overall);
            await _context.SaveChangesAsync();
        }

        public async Task<OverallRating?> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.OverallRatings
                .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }
    }
}
