using SMS.DtoLayer.ExamResult;
using SMS.WebUI.ViewModels.ExamResult;

namespace SMS.WebUI.Services.ExamResult;

public class ExamResultService(HttpClient httpClient) : IExamResultService
{
    public async Task CreateExamResultAsync(ExamResultCreateDto model)
    {
        await httpClient.PostAsJsonAsync("ExamResults/Create", model);
    }

    public async Task<List<ExamResultViewModel>> GetExamResultsAsync(int? examId, int? studentId)
    {
        var response = await httpClient.GetFromJsonAsync<ExamResultListResponseViewModel>(
            $"ExamResults/exam/{examId}?studentId={studentId}");

        // API'den gelen response'dan sonuçları alıyoruz ve döndürüyoruz
        return response?.Results ?? new List<ExamResultViewModel>();
    }


    public async Task<List<ExamResultViewModel>> GetExamResultByStudentIdAsync(int? studentId)
    {
        var response =
            await httpClient.GetFromJsonAsync<ExamResultListResponseViewModel>($"ExamResults/student/{studentId}");

        // API'den gelen response'dan sonuçları alıyoruz ve döndürüyoruz
        return response?.Results ?? new List<ExamResultViewModel>();
    }
}