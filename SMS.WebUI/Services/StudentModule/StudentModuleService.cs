using SMS.DtoLayer.StudentModule;
using SMS.WebUI.ViewModels.StudentModule;

namespace SMS.WebUI.Services.StudentModule;

public class StudentModuleService(HttpClient httpClient) : IStudentModuleService
{
    public async Task<List<StudentModuleDetailViewModel>> GetStudentModulesAsync(int studentId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<StudentModuleDetailViewModel>>(
                $"studentmodules/get-by-student/{studentId}");

            if (response == null)
            {
                return new List<StudentModuleDetailViewModel>(); // veya hata mesajı dönebilirsiniz
            }

            return response;
        }
        catch (HttpRequestException ex)
        {
            // Hata durumunda loglama yapabilirsiniz.
            // Örneğin: Logger.LogError(ex, "Error fetching student modules.");
            return new List<StudentModuleDetailViewModel>(); // Hata durumunda boş bir liste dönebiliriz
        }
    }

    public async Task AddStudentModuleAsync(StudentModuleCreateDto model)
    {
        
         await httpClient.PostAsJsonAsync("studentmodules", model);
        
    }

    public async Task<bool> RemoveStudentModuleAsync(int studentId, int moduleId)
    {
        try
        {
            var response = await httpClient.DeleteAsync(
                $"studentmodules/remove-student-module?studentId={studentId}&moduleId={moduleId}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Hata kodu veya mesajını kontrol edebilirsiniz.
                // Logger.LogError($"Error removing student module: {response.StatusCode}");
                return false;
            }
        }
        catch (HttpRequestException ex)
        {
            // Hata durumunda loglama yapabilirsiniz.
            // Logger.LogError(ex, "Error removing student module.");
            return false;
        }
    }
}