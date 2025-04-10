using SMS.Application.Repositories.ModuleRepository;
using SMS.Domain.Entities;
using SMS.Persistence.Context;

namespace SMS.Persistence.Repositories.ModuleRepository;

public class ModuleReadRepository(SMSAPIDbContext dbContext) : ReadRepository<Module>(dbContext), IModuleReadRepository
{
    
}