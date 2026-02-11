using RatingsApp.Data;
using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Implementations
{
    public class CostRepository : ICostRepository
    {
        private readonly AppDbContext _context;

        public CostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CostReduction cost)
        {
            _context.CostReductions.Add(cost);
            await _context.SaveChangesAsync();
        }

        public async Task<CostReduction?> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.CostReductions
                .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }
    }
}
