using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record TopicCreateDTO : BaseDTO
{
    public string? Name { get; set; }
    public Guid ModuleId { get; set; }
}