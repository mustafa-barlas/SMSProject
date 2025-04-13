using SMS.DtoLayer.Base;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.Module;

public record ModuleDto : BaseDTO
{
    public string? ModuleName { get; set; }
    public string? ImageUrl { get; set; }
    public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
}