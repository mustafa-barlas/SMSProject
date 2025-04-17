using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Student;
using SMS.WebUI.Models;
using SMS.WebUI.Services.Student;

namespace SMS.WebUI.Controllers;

public class StudentController(IStudentService studentService, IMapper mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var students = await studentService.GetAllStudentAsync();
        var viewModel = mapper.Map<List<GetAllStudentDto>>(students);
        return View(viewModel);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var student = await studentService.GetStudentWithAllFieldAsync(id);
        var viewModel = mapper.Map<StudentDetailDTO>(student);
        return View(viewModel);
    }

    // GET: Create
    public IActionResult Create()
    {
        return View(); // Form için boş model gönderiyoruz
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentCreateDto model)
    {
        if (ModelState.IsValid)
        {
            await studentService.CreateStudentAsync(model);
            TempData["Success"] = "Student successfully added!";
            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var student = await studentService.GetByIdStudentAsync(id);


        var dto = mapper.Map<StudentUpdateDto>(student);
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(StudentUpdateDto model)
    {
        if (ModelState.IsValid)
        {
            await studentService.UpdateStudentAsync(model);
            TempData["Success"] = "Student successfully updated!";
            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await studentService.DeleteStudentAsync(id);
        TempData["Success"] = "Student successfully deleted!";
        return RedirectToAction("Index");
    }
}