using SMS.Domain.Entities.Common;

namespace SMS.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);

    Task<bool> AddRangeAsync(List<T> datas);

    bool Remove(T model);
    Task ChangeStatusAsync(int id, bool status);

    bool RemoveRange(List<T> datas);

    Task<bool> RemoveByIdAsync(int id);

    bool Update(T model);

    Task<int> SaveAsync();
}