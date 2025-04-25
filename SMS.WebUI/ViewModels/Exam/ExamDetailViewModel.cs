using System;
using SMS.WebUI.ViewModels.ExamResult;

namespace SMS.WebUI.ViewModels.Exam;

public class ExamDetailViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ExamDate { get; set; }
    public bool Status { get; set; }

    public List<ExamResultViewModel> Results { get; set; } = new();
}