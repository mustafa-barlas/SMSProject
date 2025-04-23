using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Module;
using SMS.WebUI.Services.Module;

namespace SMS.WebUI.Controllers
{
    public class ModuleController(IModuleService moduleService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var modules = await moduleService.GetAllModuleAsync();
            return View(modules);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var module = await moduleService.GetByIdModuleAsync(id);
            return View(module);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModuleCreateDto dto)
        {
            await moduleService.CreateModuleAsync(dto);
            return RedirectToAction("Index", "Module");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var module = await moduleService.GetByIdModuleAsync(id);

            if (module == null)
                return NotFound();

            var updateModel = new ModuleUpdateDto()
            {
                Id = module.Id,
                Title = module.Title,
                ImageUrl = module.ImageUrl,
                Status = module.Status,
            };

            return View(updateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModuleUpdateDto dto)
        {
            await moduleService.UpdateModuleAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await moduleService.DeleteModuleAsync(id);
            return RedirectToAction("Index", "Module");
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] bool status)
        {
            await moduleService.ChangeModuleAsync(id, status);
            return NoContent();
        }
    }
}