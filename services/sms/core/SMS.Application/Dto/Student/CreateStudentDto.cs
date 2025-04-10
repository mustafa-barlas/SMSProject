using SMS.Application.Dto.Module;

namespace SMS.Application.Dto.Student;

public class CreateStudentDto
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public bool? Status { get; set; }
    
}