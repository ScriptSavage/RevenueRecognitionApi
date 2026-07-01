using Dal.Entities;
using Dal.Repositories.Abstract;

namespace Dal.Repositories.Customers;

public interface IIndividualCustomerRepository : IRepository<IndividualCustomer>
{
    Task<bool> DoesCustomerExist(string pesel);
}