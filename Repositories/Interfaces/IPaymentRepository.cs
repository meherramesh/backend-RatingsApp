using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task AddAsync(PaymentTerms payment);
        Task<PaymentTerms?> GetBySupplierIdAsync(int supplierId);
    }
}
