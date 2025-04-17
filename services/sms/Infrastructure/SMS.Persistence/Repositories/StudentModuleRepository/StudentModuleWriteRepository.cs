using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.StudentModuleRepository;

public class StudentModuleWriteRepository(SMSAPIDbContext context)
    : WriteRepository<StudentModule>(context), IStudentModuleWriteRepository
{
    private readonly SMSAPIDbContext _context = context;

    public async Task<bool> ExistsAsync(int studentId, int moduleId)
    {
        return await _context.StudentModules
            .AnyAsync(sm => sm.StudentId == studentId && sm.ModuleId == moduleId);
    }
}