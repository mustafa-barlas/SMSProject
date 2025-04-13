using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Student;
using StudentManagement.WebUI.Services.Student;

namespace StudentManagement.WebUI.Controllers;

public class StudentController(IStudentService studentService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var students = await studentService.GetAllStudentAsync();
        return View(students);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var student = await studentService.GetByIdStudentAsync(id);
        return View(student);
    }


    // GET: Create
    public IActionResult Create()
    {
        List<StudentCreateDTO> students = new();
        return View(students.Select(s => new StudentListDto
        {
            Name = s.Name,
            Status = Convert.ToBoolean(s.Status == true ? "Active" : "Inactive")
        }).ToList());
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentCreateDTO model)
    {
        if (ModelState.IsValid)
        {
            // Yeni öğrenci ekleme işlemi
            await studentService.CreateStudentAsync(model);
            TempData["Success"] = "Student successfully added!";
            return RedirectToAction("Index");
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        StudentDetailDTO? student  = await studentService.GetByIdStudentAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        var editDto = new StudentUpdateDTO
        {
            Id = student.Id,
            Name = student.Name,
            DateOfBirth = student.DateOfBirth,
            ImageUrl = student.ImageUrl,
            Status = student.Status
        };

        return View(editDto);
    }

    // POST: Edit
    [HttpPost]
    public async Task<IActionResult> Edit(StudentUpdateDTO model)
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
        if (ModelState.IsValid)
        {
            await studentService.DeleteStudentAsync(id);
            TempData["Success"] = "Student successfully deleted!";
        }

        return RedirectToAction("Index");
    }
}