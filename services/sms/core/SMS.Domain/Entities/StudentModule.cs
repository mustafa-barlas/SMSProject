namespace SMS.Domain.Entities;

public class StudentModule
{
    public Guid StudentId { get; set; }   
    public Student Student { get; set; }

    public Guid ModuleId { get; set; }    
    public Module Module { get; set; }
}
