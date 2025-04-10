using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SMS.Application.Repositories;
using SMS.Domain.Entities.Common;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories;

public class WriteRepository<T>(SMSAPIDbContext context) : IWriteRepository<T> where T : BaseEntity
{
    public DbSet<T> Table => context.Set<T>();


    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }

    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> ChangeStatusAsync(string? id)
    {
        var model =await Table.FirstOrDefaultAsync(x => x.Id.Equals(Guid.Parse(id)));

        if (model.Status == false || model.Status == null)
        {
            model.Status = true;
        }
        else
        {
            model.Status = false;
        }

        await SaveAsync();

        return model.Status; // Güncellenmiş durumu döndür
    }

    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }

    public async Task<bool> RemoveByIdAsync(string id)
    {
        T model = await Table.FirstOrDefaultAsync(x => x.Id.Equals(Guid.Parse(id)));
        return Remove(model);
    }

    public bool Update(T model)
    {
        EntityEntry<T> entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync() => await context.SaveChangesAsync();
}