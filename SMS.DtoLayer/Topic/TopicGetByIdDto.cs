using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record TopicGetByIdDto : BaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ModuleId { get; set; }
}