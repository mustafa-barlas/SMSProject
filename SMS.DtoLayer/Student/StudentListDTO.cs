namespace SMS.DtoLayer.Student;

public class StudentListDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool Status { get; set; }
    public string? ImageUrl { get; set; }

}