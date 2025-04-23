using SMS.DtoLayer.Base;
using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.Module;

namespace SMS.DtoLayer.Student;

public record GetAllStudentDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }
}