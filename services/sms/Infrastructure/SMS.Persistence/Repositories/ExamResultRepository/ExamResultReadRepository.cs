using SMS.Application.Repositories.ExamResultRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.ExamResultRepository;

public class ExamResultReadRepository(SMSAPIDbContext context)
    : ReadRepository<ExamResult>(context), IExamResultReadRepository
{
}