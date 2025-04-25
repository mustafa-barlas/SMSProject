using Microsoft.AspNetCore.Mvc;
using SMS.DtoLayer.Exam;
using SMS.WebUI.Services.Exam;
using SMS.WebUI.ViewModels.Exam;
using SMS.WebUI.ViewModels.ExamResult;
using ExamDetailViewModel = SMS.WebUI.ViewModels.Exam.ExamDetailViewModel;

namespace SMS.WebUI.Controllers;

public class ExamController(IExamService examService, HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IActionResult> Index()
    {
        var exams = await examService.GetAllExamAsync();
        return View(exams);
    }

    public async Task<IActionResult> Details(int examId)
    {
        var response = await _httpClient.GetAsync($"https://localhost:7109/api/ExamResults/exam/{examId}");

        if (!response.IsSuccessStatusCode)
        {
            return View("Error");
        }

        var data = await response.Content.ReadFromJsonAsync<ExamResultListResponseViewModel>();

        var viewModel = new ExamDetailViewModel
        {
            Id = examId,
            Results = data.Results.Select(r => new ExamResultViewModel
            {
                StudentName = r.StudentName,
                ModuleTitle = r.ModuleTitle,
                Correct = r.Correct,
                InCorrect = r.InCorrect,
                NetScore = r.NetScore
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ExamCreateDto model)
    {
        await examService.CreateExamAsync(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var exam = await examService.GetByIdExamAsync(id);


        var updateDto = new ExamUpdateDto
        {
            Id = exam.Id,
            Title = exam.Title,
            ExamDate = exam.ExamDate,
            Status = exam.Status,
        };

        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ExamUpdateDto model)
    {
        await examService.UpdateExamAsync(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await examService.DeleteExamAsync(id);
        return RedirectToAction(nameof(Index));
    }
}