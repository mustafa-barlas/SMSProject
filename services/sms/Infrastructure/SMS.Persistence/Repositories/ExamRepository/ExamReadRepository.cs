using SMS.Application.Repositories.ExamRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.ExamRepository;

public class ExamReadRepository(SMSAPIDbContext context) : ReadRepository<Exam>(context), IExamReadRepository
{
}