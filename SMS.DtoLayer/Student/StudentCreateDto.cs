using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Student;

public record StudentCreateDto : BaseDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }
    
}