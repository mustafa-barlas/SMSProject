using SMS.DtoLayer.Module;

namespace SMS.WebUI.Services.Module;

public interface IModuleService
{
    Task<List<ModuleDto>> GetAllModuleAsync();
    Task CreateModuleAsync(ModuleCreateDto moduleCreateDto);
    Task UpdateModuleAsync(ModuleUpdateDto moduleUpdateDto);
    Task DeleteModuleAsync(Guid moduleId);
    Task<ModuleDetailDto?> GetByIdModuleAsync(Guid moduleId);
}