using RatingsApp.Data;
using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PaymentTerms payment)
        {
            _context.PaymentTerms.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<PaymentTerms?> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.PaymentTerms
                .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }
    }
}
