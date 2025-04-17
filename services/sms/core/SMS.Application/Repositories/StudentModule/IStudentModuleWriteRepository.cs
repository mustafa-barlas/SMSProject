namespace SMS.Application.Repositories.StudentModule;

public interface IStudentModuleWriteRepository : IWriteRepository<Domain.Entities.StudentModule>
{
    Task<bool> ExistsAsync(int studentId, int moduleId);
}