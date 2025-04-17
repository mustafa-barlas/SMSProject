using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories;
using SMS.Domain.Entities.Common;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories;

public class ReadRepository<T>(SMSAPIDbContext context) : IReadRepository<T> where T : BaseEntity
{
    public DbSet<T> Table => context.Set<T>();


    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();

        query = tracking
            ? query
            : query.AsNoTracking();

        return query;
    }


    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();

        query = tracking
            ? query.Where(method)
            : query.Where(method).AsNoTracking();

        return query;
    }


    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(method);
    }

    public async Task<T> GetByIdAsync(int id, bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }


    //public async Task<T> GetByIdAsync(string id) =>await Table.FirstOrDefaultAsync(data => data.Id.Equals(Guid.Parse(id)));
}