using AutoMapper;
using SMS.DtoLayer.Exam;
using SMS.WebUI.ViewModels.Exam;

namespace SMS.WebUI.Services.Exam;

public class ExamService(HttpClient httpClient, IMapper mapper) : IExamService
{
    public async Task<List<ExamListViewModel>> GetAllExamAsync()
    {
        var response = await httpClient.GetFromJsonAsync<ExamListResponseViewModel>("exams");
        return response.Exams;
    }

    public async Task<ExamDetailViewModel?> GetByIdExamAsync(int id)
    {
        var response = await httpClient.GetAsync($"exams/{id}");
        var data = await response.Content.ReadFromJsonAsync<ExamDetailViewModel>();
        return data;
    }

    public async Task CreateExamAsync(ExamCreateDto model)
    {
        await httpClient.PostAsJsonAsync("exams/create", model);
    }

    public async Task UpdateExamAsync(ExamUpdateDto model)
    {
        await httpClient.PutAsJsonAsync("exams/update", model);
    }

    public async Task DeleteExamAsync(int id)
    {
        await httpClient.DeleteAsync($"exams/{id}");
    }

    public async Task<ExamDetailViewModel?> GetExamDetailAsync(int examId)
    {
        var response = await httpClient.GetAsync($"exams/{examId}");
        var data = await response.Content.ReadFromJsonAsync<ExamDetailViewModel>();
        return data;
    }
}