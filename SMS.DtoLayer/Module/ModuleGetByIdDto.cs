using SMS.DtoLayer.Base;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.Module;

public record ModuleGetByIdDto : BaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public List<TopicGetByIdDto> Topics { get; set; } = new List<TopicGetByIdDto>();
}