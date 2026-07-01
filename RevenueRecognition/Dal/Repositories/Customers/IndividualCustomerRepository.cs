using Dal.Context;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.Customers;

public class IndividualCustomerRepository :  IIndividualCustomerRepository
{
    
    private readonly ProjectContext  _context;

    public IndividualCustomerRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<IndividualCustomer>> GetAllAsync()
    {
        return await _context.Customers
            .OfType<IndividualCustomer>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IndividualCustomer> GetByIdAsync(long id)
    {
        return await _context.Customers
            .OfType<IndividualCustomer>()
            .FirstOrDefaultAsync(e=>e.CustomerId == id);
    }

    public async Task AddAsync(IndividualCustomer entity)
    {
        await _context.Customers.AddAsync(entity);
    }

    public void Update(IndividualCustomer entity)
    {
        _context.Customers.Update(entity);
    }

    public void Delete(IndividualCustomer entity)
    {
        _context.Customers.Remove(entity);
    }

    public async Task<bool> DoesCustomerExist(string pesel)
    { 
        return await _context.Customers.OfType<IndividualCustomer>().AnyAsync(e=>e.Pesel == pesel);
    }
    
}