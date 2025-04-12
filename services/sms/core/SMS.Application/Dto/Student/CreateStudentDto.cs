using SMS.Application.Dto.Module;

namespace SMS.Application.Dto.Student;

public class CreateStudentDto
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool? Status { get; set; }
    public string? ImageUrl { get; set; }

    
}