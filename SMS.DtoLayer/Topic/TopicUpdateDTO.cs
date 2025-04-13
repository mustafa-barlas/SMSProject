using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record TopicUpdateDTO : BaseDTO
{
    public string? TopicName { get; set; }
    public Guid ModuleId { get; set; }
}