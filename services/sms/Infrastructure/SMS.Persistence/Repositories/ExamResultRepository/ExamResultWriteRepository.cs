using SMS.Application.Repositories.ExamResultRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.ExamResultRepository;

public class ExamResultWriteRepository(SMSAPIDbContext context)
    : WriteRepository<ExamResult>(context), IExamResultWriteRepository
{
}