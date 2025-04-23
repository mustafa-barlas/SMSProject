using SMS.WebUI.ViewModels.Topic;

namespace SMS.WebUI.ViewModels.StudentModule;

public class StudentModuleViewModel
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public List<TopicViewModel> Topics { get; set; } = new List<TopicViewModel>();
}