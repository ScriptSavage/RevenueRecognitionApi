using Dal.Context;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.Customers;

public class CompanyCustomerRepository : ICompanyCustomerRepository
{
    
    private readonly ProjectContext _context;

    public CompanyCustomerRepository(ProjectContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<CompanyCustomer>> GetAllAsync()
    {
        return await _context.Customers
            .OfType<CompanyCustomer>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CompanyCustomer> GetByIdAsync(long id)
    {
        return await _context.Customers
            .OfType<CompanyCustomer>()
            .FirstOrDefaultAsync(e=>e.CustomerId == id);
    }

    public async Task AddAsync(CompanyCustomer entity)
    {
        await _context.Customers.AddAsync(entity);
    }

    public void Update(CompanyCustomer entity)
    {
        _context.Customers.Update(entity);
    }

    public void Delete(CompanyCustomer entity)
    {
        _context.Customers.Remove(entity);
    }
}