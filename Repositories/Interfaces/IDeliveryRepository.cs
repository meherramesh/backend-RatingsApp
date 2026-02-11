using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        Task AddAsync(DeliveryPerformance delivery);
        Task<DeliveryPerformance?> GetBySupplierIdAsync(int supplierId);
    }
}
