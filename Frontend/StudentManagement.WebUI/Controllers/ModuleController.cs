using Microsoft.AspNetCore.Mvc;
using StudentManagement.WebUI.Services.Module;
using SMS.DtoLayer.Module;

namespace StudentManagement.WebUI.Controllers
{
    public class ModuleController(IModuleService moduleService) : Controller
    {
        // Listeleme
        public async Task<IActionResult> Index()
        {
            var modules = await moduleService.GetAllModuleAsync();
            return View(modules);
        }

        // Detay
        public async Task<IActionResult> Detail(Guid id)
        {
            var module = await moduleService.GetByIdModuleAsync(id);
            if (module == null) return NotFound();
            return View(module);
        }

        // Yeni Ekleme (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Ekleme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModuleCreateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await moduleService.CreateModuleAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme (GET)
        public async Task<IActionResult> Edit(Guid id)
        {
            var module = await moduleService.GetByIdModuleAsync(id);
            if (module == null) return NotFound();

            var updateDto = new ModuleUpdateDTO
            {
                Id = module.Id,
                ModuleName = module.ModuleName,
                ImageUrl = module.ImageUrl,
                Status = module.Status
            };

            return View(updateDto);
        }

        // Güncelleme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModuleUpdateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await moduleService.UpdateModuleAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await moduleService.DeleteModuleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}