using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record TopicCreateDTO : BaseDTO
{
    public string? TopicName { get; set; }
    public Guid ModuleId { get; set; }
}