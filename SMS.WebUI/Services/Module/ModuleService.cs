using SMS.DtoLayer.Module;

namespace SMS.WebUI.Services.Module;

public class ModuleService(HttpClient httpClient) : IModuleService
{
    public async Task<List<ModuleDto>> GetAllModuleAsync()
    {
        var response = await httpClient.GetFromJsonAsync<ModuleListDto>("Modules");
        return response?.Modules ?? new();
    }


    public async Task<ModuleDetailDto?> GetByIdModuleAsync(Guid moduleId)
    {
        var response = await httpClient.GetAsync($"Modules/{moduleId}");
        return await response.Content.ReadFromJsonAsync<ModuleDetailDto>();
    }

    public async Task CreateModuleAsync(ModuleCreateDto dto)
    {
        var response = await httpClient.PostAsJsonAsync("Modules", dto);
    }

    public async Task UpdateModuleAsync(ModuleUpdateDto dto)
    {
        var response = await httpClient.PutAsJsonAsync($"Modules/{dto.Id}", dto);
    }

    public async Task DeleteModuleAsync(Guid moduleId)
    {
        var response = await httpClient.DeleteAsync($"Modules/{moduleId}");
    }
}