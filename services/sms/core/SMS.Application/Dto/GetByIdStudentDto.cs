namespace SMS.Application.Dto;

public class GetByIdStudentDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public bool? Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public List<ModuleDto>? Modules { get; set; } = new List<ModuleDto>();
}