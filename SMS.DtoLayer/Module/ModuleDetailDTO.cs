using SMS.DtoLayer.StudentModule;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.Module;

public class ModuleDetailDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public List<TopicDTO> Topics { get; set; } = new List<TopicDTO>();
    public List<StudentModuleDTO> StudentModules { get; set; } = new List<StudentModuleDTO>();
}