using SMS.DtoLayer.Module;
using SMS.WebUI.ViewModels.Module;

namespace SMS.WebUI.Services.Module;

public interface IModuleService
{
    Task<List<ModuleViewModel>> GetAllModuleAsync();
    Task CreateModuleAsync(ModuleCreateDto model);
    Task UpdateModuleAsync(ModuleUpdateDto model);
    Task DeleteModuleAsync(int moduleId);
    Task<ModuleViewModel?> GetByIdModuleAsync(int moduleId);

    Task ChangeModuleAsync(int moduleId, bool status);
}