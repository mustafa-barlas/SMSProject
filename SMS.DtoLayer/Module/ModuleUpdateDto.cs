using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Module;

public record ModuleUpdateDto : BaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
}