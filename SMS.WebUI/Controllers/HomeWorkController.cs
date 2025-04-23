using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.HomeWork;
using SMS.WebUI.Services.HomeWork;

namespace SMS.WebUI.Controllers;

public class HomeWorkController(IHomeWorkService homeWorkService) : Controller
{
    // Ödev listesi - öğrenciye göre
    [HttpGet]
    public async Task<IActionResult> Index(int studentId)
    {
        var homeworks = await homeWorkService.GetAllHomeworkByStudentId(studentId);
        ViewBag.StudentId = studentId;
        return View(homeworks);
    }

    // Ödev oluşturma formu
    [HttpGet]
    public IActionResult Create(int studentId)
    {
        var model = new HomeWorkCreateDto { StudentId = studentId };
        return RedirectToAction("Details", "Student", model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFromStudent(HomeWorkCreateDto dto)
    {
        await homeWorkService.CreateAsync(dto);
        return RedirectToAction("Details", "Student", new { id = dto.StudentId });
    }



    // Ödev düzenleme formu
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var homework = await homeWorkService.GetByIdAsync(id);
        var dto = new HomeWorkUpdateDto
        {
            Id = homework.Id,
            Title = homework.Title,
            Content = homework.Content,
            // Deadline = homework.Deadline,
            StudentId = homework.StudentId
        };
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(HomeWorkUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await homeWorkService.UpdateAsync(dto);
        return RedirectToAction("Index", new { studentId = dto.StudentId });
    }

    // Ödev silme işlemi
    [HttpPost]
    public async Task<IActionResult> Delete(int homeworkId, int studentId)
    {
        await homeWorkService.DeleteAsync(homeworkId);
        return RedirectToAction("Index", new { studentId });
    }
}