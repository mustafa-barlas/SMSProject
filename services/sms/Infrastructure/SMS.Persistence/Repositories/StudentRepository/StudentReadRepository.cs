using SMS.Application.Repositories.StudentRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.StudentRepository;

public class StudentReadRepository(SMSAPIDbContext dbContext) : ReadRepository<Student>(dbContext), IStudentReadRepository;