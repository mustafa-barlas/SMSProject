namespace SMS.WebUI.ViewModels.Module;

public class ModuleViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Status { get; set; }
}