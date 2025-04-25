using SMS.DtoLayer.ExamResult;
using SMS.WebUI.ViewModels.ExamResult;

namespace SMS.WebUI.Services.ExamResult;

public interface IExamResultService
{
    Task CreateExamResultAsync(ExamResultCreateDto model);

    Task<List<ExamResultViewModel>> GetExamResultsAsync(int? examId, int? studentId); 
}