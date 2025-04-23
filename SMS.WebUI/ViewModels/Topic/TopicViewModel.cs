using SMS.DtoLayer.Base;

namespace SMS.WebUI.ViewModels.Topic;

public record TopicViewModel : BaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ModuleId { get; set; }
    public bool Status { get; set; }
}