namespace SMS.DtoLayer.StudentModule;

public class StudentModuleUpdateDTO
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public bool IsActive { get; set; }
}