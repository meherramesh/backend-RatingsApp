using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(PaymentTerms payment)
        {
            await _repository.AddAsync(payment);
        }

        public async Task<PaymentTerms?> GetBySupplierIdAsync(int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }
    }
}
