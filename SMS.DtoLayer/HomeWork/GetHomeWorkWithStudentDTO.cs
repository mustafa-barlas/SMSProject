using SMS.DtoLayer.Base;
using SMS.DtoLayer.Student;

namespace SMS.DtoLayer.HomeWork;

public record GetHomeWorkWithStudentDTO : BaseDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public StudentDetailDTO StudentDetailDto { get; set; }
}