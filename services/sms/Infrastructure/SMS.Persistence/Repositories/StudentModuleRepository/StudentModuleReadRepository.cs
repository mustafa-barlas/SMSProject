using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.StudentModuleRepository;

public class StudentModuleReadRepository(SMSAPIDbContext context)
    : ReadRepository<StudentModule>(context), IStudentModuleReadRepository
{
    public async Task<ICollection<StudentModule>> GetByStudentIdAsync(Guid studentId)
    {
        return await context.StudentModules
            .Include(sm => sm.Module) // navigation property
            .Where(sm => sm.StudentId == studentId)
            .ToListAsync();
    }

    public async Task<List<StudentModule>> GetWithModulesAndTopicsByStudentIdAsync(Guid studentId)
    {
        return await context.StudentModules
            .Where(sm => sm.StudentId == studentId)
            .Include(sm => sm.Module)
            .ThenInclude(m => m.Topics)
            .ToListAsync();
    }
}