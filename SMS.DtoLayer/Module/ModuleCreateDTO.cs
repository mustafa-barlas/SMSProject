using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Module;

public record ModuleCreateDTO : BaseDTO
{
    public string? ModuleName { get; set; }
    public string? ImageUrl { get; set; }
}