using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.WebUI.ViewModels.StudentModule;

public class StudentModuleCreateViewModel
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }

    public IEnumerable<SelectListItem>? Students { get; set; }
    public IEnumerable<SelectListItem>? Modules { get; set; }
}