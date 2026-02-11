using RatingsApp.Data;
using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Implementations
{
    public class QualityRepository : IQualityRepository
    {
        private readonly AppDbContext _context;

        public QualityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(QualityPerformance quality)
        {
            _context.QualityPerformances.Add(quality);
            await _context.SaveChangesAsync();
        }

        public async Task<QualityPerformance?> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.QualityPerformances
                .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }
    }
}
