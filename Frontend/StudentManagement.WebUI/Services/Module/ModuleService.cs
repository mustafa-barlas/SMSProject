using SMS.DtoLayer.Module;

namespace StudentManagement.WebUI.Services.Module;

public class ModuleService(HttpClient httpClient) : IModuleService
{
    public async Task<List<ModuleDto>> GetAllModuleAsync()
    {
        var response = await httpClient.GetFromJsonAsync<ModuleListDto>("api/Modules");
        return response?.Modules ?? new();
    }


    public async Task<ModuleDetailDto?> GetByIdModuleAsync(Guid moduleId)
    {
        var response = await httpClient.GetAsync($"/api/Modules/{moduleId}");
        return await response.Content.ReadFromJsonAsync<ModuleDetailDto>();
    }

    public async Task CreateModuleAsync(ModuleCreateDTO dto)
    {
        var response = await httpClient.PostAsJsonAsync("/api/Modules", dto);
    }

    public async Task UpdateModuleAsync(ModuleUpdateDTO dto)
    {
        var response = await httpClient.PutAsJsonAsync($"/api/Modules/{dto.Id}", dto);
    }

    public async Task DeleteModuleAsync(Guid moduleId)
    {
        var response = await httpClient.DeleteAsync($"/api/Modules/{moduleId}");
    }
}