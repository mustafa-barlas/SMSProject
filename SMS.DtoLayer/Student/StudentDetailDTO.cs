using SMS.DtoLayer.Base;
using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.StudentModule;

namespace SMS.DtoLayer.Student;

public record StudentDetailDTO : BaseDTO
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }

    public List<StudentModuleDto> StudentModules { get; set; } = new List<StudentModuleDto>();
    public List<HomeWorkDTO> HomeWorks { get; set; } = new List<HomeWorkDTO>();
}