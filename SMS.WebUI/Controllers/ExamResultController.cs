using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.DtoLayer.ExamResult;
using SMS.WebUI.Services.ExamResult;
using SMS.WebUI.Services.Student; // Öğrenci servisi
using SMS.WebUI.Services.Exam; // Sınav servisi
using SMS.WebUI.Services.Module;
using SMS.WebUI.Services.Pdf; // Modül servisi

namespace SMS.WebUI.Controllers
{
    public class ExamResultController(
        IExamResultService examResultService,
        IStudentService studentService,
        IExamService examService,
        IModuleService moduleService,
        IExamResultPdfService examResultPdfService)
        : Controller
    {
        // GET: ExamResult/Create
        public async Task<IActionResult> Create()
        {
            var students = await studentService.GetAllStudentAsync(); // Öğrencileri al
            var exams = await examService.GetAllExamAsync(); // Sınavları al
            var modules = await moduleService.GetAllModuleAsync(); // Modülleri al

            ViewBag.Students = new SelectList(students, "Id", "Name"); // Öğrenciyi "Id" ve "Name" ile göster
            ViewBag.Exams = new SelectList(exams, "Id", "Title"); // Sınavı "Id" ve "Name" ile göster
            ViewBag.Modules = new SelectList(modules, "Id", "Title"); // Modülü "Id" ve "Name" ile göster

            return View();
        }

        // POST: ExamResult/Create
        [HttpPost]
        public async Task<IActionResult> Create(ExamResultCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await examResultService.CreateExamResultAsync(dto); // Sonuç oluşturma işlemi
                return RedirectToAction("Create", "ExamResult"); // Oluşturduktan sonra başka bir sayfaya yönlendir
            }

            // Eğer model geçerli değilse, dropdownları tekrar doldurup aynı sayfayı göster
            var students = await studentService.GetAllStudentAsync();
            var exams = await examService.GetAllExamAsync();
            var modules = await moduleService.GetAllModuleAsync();

            ViewBag.Students = new SelectList(students, "Id", "Name");
            ViewBag.Exams = new SelectList(exams, "Id", "Title");
            ViewBag.Modules = new SelectList(modules, "Id", "Title");

            return View(dto); // Geçersiz model ile aynı sayfayı geri döndür
        }

        public async Task<IActionResult> GetExamResults(int? examId, int? studentId)
        {
            var students = await studentService.GetAllStudentAsync();
            var exams = await examService.GetAllExamAsync();

            ViewBag.Students = students;
            ViewBag.Exams = exams;

            var selectedStudentId = studentId ?? students.FirstOrDefault()?.Id ?? 0;
            var selectedExamId = examId ?? exams.FirstOrDefault()?.Id ?? 0;

            var result = await examResultService.GetExamResultsAsync(selectedExamId, selectedStudentId);

            return View(result);
        }
        
        public async Task<IActionResult> GetExams(int? examId, int? studentId)
        {
            var result = await examResultService.GetExamResultsAsync(examId, studentId);

            return PartialView("_ExamListPartial", result);
        }
        
        [HttpPost]
        public async Task<IActionResult> DownloadExamResultsPdf(int? examId, int? studentId)
        {
            var pdfBytes = await examResultPdfService.GenerateExamResultsPdfAsync(examId, studentId);
            return File(pdfBytes, "application/pdf", "SinavSonuclari.pdf");
        }
    }
}