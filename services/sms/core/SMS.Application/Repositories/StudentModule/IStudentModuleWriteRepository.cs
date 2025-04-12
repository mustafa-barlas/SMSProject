namespace SMS.Application.Repositories.StudentModule;

public interface IStudentModuleWriteRepository : IWriteRepository<Domain.Entities.StudentModule>
{
    Task<bool> ExistsAsync(Guid studentId, Guid moduleId);
}