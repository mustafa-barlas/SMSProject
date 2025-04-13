using SMS.DtoLayer.Module;

namespace StudentManagement.WebUI.Services.Module;

public interface IModuleService
{
    Task<List<ModuleDto>> GetAllModuleAsync();
    Task CreateModuleAsync(ModuleCreateDTO moduleCreateDto);
    Task UpdateModuleAsync(ModuleUpdateDTO moduleUpdateDto);
    Task DeleteModuleAsync(Guid moduleId);
    Task<ModuleDetailDto?> GetByIdModuleAsync(Guid moduleId);
}