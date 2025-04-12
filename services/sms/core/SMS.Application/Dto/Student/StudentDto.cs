using SMS.Application.Dto.HomeWork;
using SMS.Application.Dto.Module;

namespace SMS.Application.Dto.Student;

public class StudentDto
{
    public string StudentId { get; set; }
    public string? StudentName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }

    public bool? Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public List<ModuleDto> Modules { get; set; } = new List<ModuleDto>();

    public List<GetByIdHomeWorkDto> HomeWorks { get; set; } = new List<GetByIdHomeWorkDto>();
}