using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.HomeWork;
using StudentManagement.WebUI.Services.HomeWork;

namespace StudentManagement.WebUI.Controllers;

public class HomeWorkController(IHomeWorkService homeWorkService) : Controller
{
    public async Task<IActionResult> Index(Guid studentId)
    {
        var homeworks = await homeWorkService.GetHomeworksByStudentIdAsync(studentId);
        ViewBag.StudentId = studentId;
        return View(homeworks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(HomeWorkCreateDTO dto)
    {
        await homeWorkService.CreateAsync(dto);
        return RedirectToAction("Index", new { studentId = dto.StudentId });
    }

    [HttpPost]
    public async Task<IActionResult> Update(HomeWorkUpdateDTO dto)
    {
        await homeWorkService.UpdateAsync(dto);
        return RedirectToAction("Index", new { studentId = dto.StudentId });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid homeworkId, Guid studentId)
    {
        await homeWorkService.DeleteAsync(homeworkId);
        return RedirectToAction("Index", new { studentId });
    }
}