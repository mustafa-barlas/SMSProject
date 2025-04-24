using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.StudentModule;
using SMS.WebUI.Services.StudentModule;
using SMS.WebUI.ViewModels.StudentModule;

namespace SMS.WebUI.Controllers
{
    public class StudentModuleController(IStudentModuleService studentModuleService) : Controller
    {
        // Öğrencinin modüllerini listele
        public async Task<IActionResult> Index(int studentId)
        {
            var studentModules = await studentModuleService.GetStudentModulesAsync(studentId);
            return View(studentModules);
        }


        // Öğrenciye modül ekle
        [HttpPost]
        public async Task<IActionResult> AddModuleToStudent(int studentId, int moduleId)
        {
            var model = new StudentModuleCreateDto()
            {
                StudentId = studentId,
                ModuleId = moduleId
            };

            await studentModuleService.AddStudentModuleAsync(model);

            return RedirectToAction("Details", "Student", new { id = studentId });
        }


        // Öğrenciden modül çıkar
        [HttpPost]
        public async Task<IActionResult> RemoveStudentModule(int studentId, int moduleId)
        {
            await studentModuleService.RemoveStudentModuleAsync(studentId, moduleId);
            return RedirectToAction("Details", "Student", new { id = studentId });
        }
    }
}