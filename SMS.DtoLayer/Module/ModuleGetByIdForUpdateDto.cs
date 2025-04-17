using SMS.DtoLayer.Base;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.Module;

public record ModuleGetByIdForUpdateDto : BaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
}