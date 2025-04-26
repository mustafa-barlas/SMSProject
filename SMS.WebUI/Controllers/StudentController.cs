using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.DtoLayer.Student;
using SMS.WebUI.Services.Exam;
using SMS.WebUI.Services.ExamResult;
using SMS.WebUI.Services.HomeWork;
using SMS.WebUI.Services.Module;
using SMS.WebUI.Services.Student;

namespace SMS.WebUI.Controllers
{
    public class StudentController(
        IStudentService studentService,
        IMapper mapper,
        IHomeWorkService homeWorkService,
        IModuleService moduleService,
        IExamResultService examResultService,
        IExamService examService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await studentService.GetAllStudentAsync();
            return View(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var studentDto = await studentService.GetByIdStudentAsync(id);
            var modules = await moduleService.GetAllModuleAsync();

            // SelectListItem kullanarak SelectList oluşturma
            ViewBag.Modules = new SelectList(modules, "Id", "Title");
            return View(studentDto);
        }
        
        // public async Task<IActionResult> Details( int? examId,int? studentId)
        // {
        //     var studentDto = await studentService.GetByIdStudentAsync(studentId);
        //     var modules = await moduleService.GetAllModuleAsync();
        //
        //     var exams = await examService.GetAllExamAsync();
        //
        //     ViewBag.Exams = exams;
        //
        //     var selectedExamId = examId ?? exams.FirstOrDefault()?.Id ?? 0;
        //
        //     var result = await examResultService.GetExamResultsAsync(selectedExamId, studentId);
        //
        //     ViewBag.Modules = new SelectList(modules, "Id", "Title");
        //     return View((studentDto,result));
        // }
        
        
        // public async Task<IActionResult> GetExamResultByStudent(int? examId, int? studentId)
        // {
        //     var result = await examResultService.GetExamResultsAsync(examId, studentId);
        //
        //     return PartialView("_ExamResultsPartial", result);
        // }

        [HttpGet]
        [Route("createStudent")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("createStudent")]
        public async Task<IActionResult> Create(StudentCreateDto model)
        {
            await studentService.CreateStudentAsync(model);
            return RedirectToAction("Index", "Student");
        }

        [HttpGet]
        [Route("updateStudent/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await studentService.GetByIdStudentAsync(id);

            var updateModel = new StudentUpdateDto()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                DateOfBirth = student.DateOfBirth,
                ImageUrl = student.ImageUrl,
                Status = student.Status
            };

            return View(updateModel);
        }

        [HttpPost]
        [Route("updateStudent/{id}")]
        public async Task<IActionResult> Edit(StudentUpdateDto model)
        {
            await studentService.UpdateStudentAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await studentService.DeleteStudentAsync(id);
            return RedirectToAction("Index", "Student");
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] bool status)
        {
            await studentService.ChangeStudentAsync(id, status);
            return NoContent();
        }

        // [HttpPost]
        // public async Task<IActionResult> AddAssignment(HomeWorkCreateDto dto)
        // {
        //     
        //
        //     await homeWorkService.CreateAsync(dto);
        //     return RedirectToAction("Details", new { id = dto.StudentId });
        // }
    }
}