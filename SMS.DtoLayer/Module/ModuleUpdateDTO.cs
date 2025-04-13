using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Module;

public record ModuleUpdateDTO : BaseDTO
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
}