using Microsoft.AspNetCore.Mvc;

namespace SMS.WebUI.ViewComponent.LayoutViewComponent;

public class FooterViewComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}