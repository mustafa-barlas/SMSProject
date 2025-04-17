using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Student;

public record StudentUpdateDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }
}