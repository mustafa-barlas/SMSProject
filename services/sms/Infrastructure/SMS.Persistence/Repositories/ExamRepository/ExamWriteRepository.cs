using SMS.Application.Repositories.ExamRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.ExamRepository;

public class ExamWriteRepository(SMSAPIDbContext context) : WriteRepository<Exam>(context), IExamWriteRepository
{
}