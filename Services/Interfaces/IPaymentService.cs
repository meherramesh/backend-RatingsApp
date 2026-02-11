using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Services.Interfaces
{
    public interface IPaymentService
    {
        Task AddAsync(PaymentTerms payment);
        Task<PaymentTerms?> GetBySupplierIdAsync(int supplierId);
    }
}
