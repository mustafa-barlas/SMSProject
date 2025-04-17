using SMS.DtoLayer.Base;
using SMS.DtoLayer.HomeWork;

namespace SMS.DtoLayer.Student;

public record StudentGetByIdForUpdateDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }
}