using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Student;

public record StudentCreateDTO : BaseDTO
{
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }

}