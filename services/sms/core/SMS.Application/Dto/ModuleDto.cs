namespace SMS.Application.Dto;

public abstract class ModuleDto
{
    public string? ModuleName { get; set; }
    public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
}