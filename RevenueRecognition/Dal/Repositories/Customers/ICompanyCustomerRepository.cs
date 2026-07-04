using Dal.Entities;
using Dal.Repositories.Abstract;

namespace Dal.Repositories.Customers;

public interface ICompanyCustomerRepository : IRepository<CompanyCustomer>
{
   Task<bool> DoesCompanyKrsExist(string krs);
}