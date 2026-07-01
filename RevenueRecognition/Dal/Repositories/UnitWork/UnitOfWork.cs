using System.Data;
using Dal.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dal.Repositories.UnitWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProjectContext  _context;

    public UnitOfWork(ProjectContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}