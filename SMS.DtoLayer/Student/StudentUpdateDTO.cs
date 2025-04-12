namespace SMS.DtoLayer.Student;

public class StudentUpdateDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }

}