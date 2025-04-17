
namespace SMS.Application.Repositories.StudentModule;

public interface IStudentModuleReadRepository :IReadRepository<Domain.Entities.StudentModule>
{
    Task<ICollection<Domain.Entities.StudentModule>> GetByStudentIdAsync(int studentId);
    Task<List<Domain.Entities.StudentModule>> GetWithModulesAndTopicsByStudentIdAsync(int studentId);

}