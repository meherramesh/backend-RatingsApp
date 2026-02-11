using RatingsApp.Data;
using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Implementations
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly AppDbContext _context;

        public ResponseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ResponsePerformance response)
        {
            _context.ResponsePerformances.Add(response);
            await _context.SaveChangesAsync();
        }

        public async Task<ResponsePerformance?> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.ResponsePerformances
                .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }
    }
}
