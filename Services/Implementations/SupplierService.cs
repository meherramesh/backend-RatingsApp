using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierService(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Supplier>> GetSuppliersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Supplier?> GetSupplierAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddSupplierAsync(Supplier supplier)
    {
        await _repository.AddAsync(supplier);
    }
}
