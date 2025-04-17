using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.StudentModuleRepository;

public class StudentModuleReadRepository(SMSAPIDbContext context) : ReadRepository<StudentModule>(context), IStudentModuleReadRepository
{
    private readonly SMSAPIDbContext _context = context;

    public async Task<ICollection<StudentModule>> GetByStudentIdAsync(int studentId)
    {
        return await _context.StudentModules
            .Include(sm => sm.Module) // navigation property
            .Where(sm => sm.StudentId == studentId)
            .ToListAsync();
    }

    public async Task<List<StudentModule>> GetWithModulesAndTopicsByStudentIdAsync(int studentId)
    {
        return await _context.StudentModules
            .Where(sm => sm.StudentId == studentId)
            .Include(sm => sm.Module)
            .ThenInclude(m => m.Topics)
            .ToListAsync();
    }
}