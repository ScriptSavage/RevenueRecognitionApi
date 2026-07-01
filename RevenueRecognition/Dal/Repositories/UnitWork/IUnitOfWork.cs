using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dal.Repositories.UnitWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    
    Task<IDbContextTransaction> BeginTransactionAsync();
}