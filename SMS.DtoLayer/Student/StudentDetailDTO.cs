using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.StudentModule;

namespace SMS.DtoLayer.Student;

public class StudentDetailDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }

    public List<StudentModuleDTO> StudentModules { get; set; } = new List<StudentModuleDTO>();
    public List<HomeWorkDTO> HomeWorks { get; set; } = new List<HomeWorkDTO>();
}