using SMS.DtoLayer.Base;
using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.Module;

namespace SMS.DtoLayer.Student;

public record GetStudentWithModuleAndTopicDto : BaseDTO
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public List<ModuleListDto>? Modules { get; set; }
    public List<HomeWorkDTO>? HomeWorks { get; set; }
}