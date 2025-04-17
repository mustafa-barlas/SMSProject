using SMS.DtoLayer.Base;
using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.StudentModule;

namespace SMS.DtoLayer.Student;

public record StudentGetByIdDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }

    public List<StudentModuleGetByIdDto> StudentModules { get; set; } = new List<StudentModuleGetByIdDto>();
    public List<GetAllHomeworkDto> HomeWorks { get; set; } = new List<GetAllHomeworkDto>(); 
}