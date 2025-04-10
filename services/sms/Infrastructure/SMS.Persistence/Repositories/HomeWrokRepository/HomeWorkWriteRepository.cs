using SMS.Application.Repositories.HomeWorkRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.HomeWrokRepository;

public class HomeWorkWriteRepository(SMSAPIDbContext context) : WriteRepository<HomeWork>(context), IHomeWorkWriteRepository
{
    
}