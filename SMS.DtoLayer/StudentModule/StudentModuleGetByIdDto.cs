using SMS.DtoLayer.Base;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.StudentModule;

public record StudentModuleGetByIdDto : BaseDto
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<TopicGetByIdDto> TopicDtos { get; set; } = new List<TopicGetByIdDto>();
}