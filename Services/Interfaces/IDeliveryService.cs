using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Services.Interfaces
{
    public interface IDeliveryService
    {
        Task AddAsync(DeliveryPerformance delivery);
        Task<DeliveryPerformance?> GetBySupplierIdAsync(int supplierId);
    }
}
