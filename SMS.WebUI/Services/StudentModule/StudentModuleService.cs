using SMS.WebUI.ViewModels.StudentModule;

namespace SMS.WebUI.Services.StudentModule;

public class StudentModuleService(HttpClient httpClient) : IStudentModuleService
{
    public async Task<List<StudentModuleDetailViewModel>> GetStudentModulesAsync(int studentId)
    {
        var response =
            await httpClient.GetFromJsonAsync<List<StudentModuleDetailViewModel>>(
                $"studentmodules/get-by-student/{studentId}");
        return response ?? new List<StudentModuleDetailViewModel>();
    }

    public async Task<bool> AddStudentModuleAsync(StudentModuleCreateViewModel model)
    {
        var response = await httpClient.PostAsJsonAsync("studentmodules", model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveStudentModuleAsync(int studentId, int moduleId)
    {
        var response =
            await httpClient.DeleteAsync(
                $"studentmodules/remove-student-module?studentId={studentId}&moduleId={moduleId}");
        return response.IsSuccessStatusCode;
    }
}