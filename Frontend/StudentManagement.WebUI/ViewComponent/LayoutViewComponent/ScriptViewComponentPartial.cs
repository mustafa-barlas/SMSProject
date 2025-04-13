using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.WebUI.ViewComponent.LayoutViewComponent;

public class ScriptViewComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}