using SMS.WebUI.ViewModels.Topic;

namespace SMS.WebUI.ViewModels.Module;

public class ModuleDetailViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Status { get; set; }
    public List<TopicViewModel> Topics { get; set; } = new List<TopicViewModel>();
}