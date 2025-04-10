using SMS.Application.Dto.Topic;

namespace SMS.Application.Dto.Module;

public class GetByIdModuleDto
{
    public string ModuleId { get; set; }
    public string? ModuleName { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
    public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
}