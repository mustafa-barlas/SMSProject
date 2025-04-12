
namespace SMS.Application.Repositories.StudentModule;

public interface IStudentModuleReadRepository :IReadRepository<Domain.Entities.StudentModule>
{
    Task<ICollection<Domain.Entities.StudentModule>> GetByStudentIdAsync(Guid studentId);
    Task<List<Domain.Entities.StudentModule>> GetWithModulesAndTopicsByStudentIdAsync(Guid studentId);

}