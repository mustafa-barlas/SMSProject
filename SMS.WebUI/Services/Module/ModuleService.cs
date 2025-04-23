using SMS.DtoLayer.Module;
using SMS.WebUI.ViewModels.Module;

namespace SMS.WebUI.Services.Module;

public class ModuleService(HttpClient httpClient) : IModuleService
{
    public async Task CreateModuleAsync(ModuleCreateDto model)
    {
        await httpClient.PostAsJsonAsync("modules/create", model);
    }

    public async Task UpdateModuleAsync(ModuleUpdateDto model)
    {
        var response = await httpClient.PutAsJsonAsync($"modules/update", model);
    }

    public async Task DeleteModuleAsync(int moduleId)
    {
        await httpClient.DeleteAsync($"Modules/{moduleId}");
    }

    public async Task<ModuleViewModel?> GetByIdModuleAsync(int moduleId)
    {
        var response = await httpClient.GetFromJsonAsync<ModuleResponseModel>($"modules/{moduleId}");
        return response?.Module;
    }

    public async Task ChangeModuleAsync(int moduleId, bool status)
    {
        await httpClient.PutAsJsonAsync($"modules/{moduleId}/status", new { Status = status });
    }

    public async Task<List<ModuleViewModel>> GetAllModuleAsync()
    {
        var response = await httpClient.GetFromJsonAsync<ModuleListViewModel>("modules");
        return response.Modules;
    }
}