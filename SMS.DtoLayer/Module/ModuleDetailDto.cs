using SMS.DtoLayer.Base;
using SMS.DtoLayer.StudentModule;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.Module;

public record ModuleDetailDto : BaseDTO
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
    public List<StudentModuleDto> StudentModules { get; set; } = new List<StudentModuleDto>();
}