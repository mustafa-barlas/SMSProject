using SMS.Application.Repositories.TopicRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.TopicRepository;

public class TopicWriteRepository(SMSAPIDbContext context) : WriteRepository<Topic>(context), ITopicWriteRepository
{
}