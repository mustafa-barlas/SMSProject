using SMS.DtoLayer.StudentModule;
using SMS.WebUI.ViewModels.StudentModule;

namespace SMS.WebUI.Services.StudentModule;

public interface IStudentModuleService
{
    Task<List<StudentModuleDetailViewModel>> GetStudentModulesAsync(int studentId);
    Task AddStudentModuleAsync(StudentModuleCreateDto model);
    Task<bool> RemoveStudentModuleAsync(int studentId, int moduleId);
}