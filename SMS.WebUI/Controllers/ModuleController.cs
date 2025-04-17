using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Module;
using SMS.WebUI.Services.Module;

namespace SMS.WebUI.Controllers
{
    public class ModuleController(IModuleService moduleService, IMapper mapper) : Controller
    {
        // Listeleme
        public async Task<IActionResult> Index()
        {
            var modules = await moduleService.GetAllModuleAsync();
            var viewModel = mapper.Map<List<ModuleDto>>(modules);

            return View(viewModel);
        }

        // Detay
        public async Task<IActionResult> Detail(Guid id)
        {
            var module = await moduleService.GetByIdModuleAsync(id);
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
        public async Task<IActionResult> Create(ModuleCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await moduleService.CreateModuleAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme (GET)
        public async Task<IActionResult> Edit(Guid id)
        {
            var module = await moduleService.GetByIdModuleAsync(id);

            var updateDto = new ModuleUpdateDto
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
        public async Task<IActionResult> Edit(ModuleUpdateDto dto)
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