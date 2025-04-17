using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Module;

public record ModuleCreateDto : BaseDto
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
}