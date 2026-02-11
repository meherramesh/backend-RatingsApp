using RatingsApp.Models;
using Microsoft.EntityFrameworkCore;

public interface ISupplierService
{
    Task<List<Supplier>> GetSuppliersAsync();
    Task<Supplier?> GetSupplierAsync(int id);
    Task AddSupplierAsync(Supplier supplier);
}
