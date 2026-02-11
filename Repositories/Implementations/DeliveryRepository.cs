using RatingsApp.Data;
using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Implementations
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly AppDbContext _context;

        public DeliveryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DeliveryPerformance delivery)
        {
            _context.DeliveryPerformances.Add(delivery);
            await _context.SaveChangesAsync();
        }

        public async Task<DeliveryPerformance?> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.DeliveryPerformances
                .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }
    }
}
