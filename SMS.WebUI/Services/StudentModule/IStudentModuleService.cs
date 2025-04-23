using SMS.WebUI.ViewModels.StudentModule;

namespace SMS.WebUI.Services.StudentModule;

public interface IStudentModuleService
{
    Task<List<StudentModuleDetailViewModel>> GetStudentModulesAsync(int studentId);
    Task<bool> AddStudentModuleAsync(StudentModuleCreateViewModel model);
    Task<bool> RemoveStudentModuleAsync(int studentId, int moduleId);
}