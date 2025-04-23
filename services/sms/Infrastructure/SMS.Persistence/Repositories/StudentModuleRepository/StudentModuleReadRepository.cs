using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.StudentModuleRepository;

public class StudentModuleReadRepository(SMSAPIDbContext context)
    : ReadRepository<StudentModule>(context), IStudentModuleReadRepository;