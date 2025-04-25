namespace SMS.WebUI.Services.Exam;

using SMS.DtoLayer.Exam;
using SMS.WebUI.ViewModels.Exam;

public interface IExamService
{
    Task<List<ExamListViewModel>> GetAllExamAsync();
    Task<ExamDetailViewModel?> GetByIdExamAsync(int id);
    Task CreateExamAsync(ExamCreateDto model);
    Task UpdateExamAsync(ExamUpdateDto model);
    Task DeleteExamAsync(int id);
    
    Task<ExamDetailViewModel?> GetExamDetailAsync(int examId);

}

