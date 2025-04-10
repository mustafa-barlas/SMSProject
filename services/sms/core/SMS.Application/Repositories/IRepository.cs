using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities.Common;

namespace SMS.Application.Repositories;

public interface IRepository<T> where T : class
{
    DbSet<T> Table { get; }
}