using Microsoft.EntityFrameworkCore;
using RatingsApp.Data;
using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;

namespace RatingsApp.Repositories.Implementations
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers
                .Include(s => s.QualityPerformance)
                .Include(s => s.DeliveryPerformance)
                .Include(s => s.CostReduction)
                .Include(s => s.PaymentTerms)
                .Include(s => s.ResponsePerformance)
                .Include(s => s.OverallRating)
                .ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task AddAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
