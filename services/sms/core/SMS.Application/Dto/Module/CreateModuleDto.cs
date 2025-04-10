namespace SMS.Application.Dto.Module;

public class CreateModuleDto
{
    public string? ModuleName { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
}