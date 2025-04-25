namespace SMS.WebUI.ViewModels.ExamResult;

public class ExamResultViewModel
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ExamId { get; set; }
    public string ExamTitle { get; set; }
    public int ModuleId { get; set; }
    public string ModuleTitle { get; set; }
    public int Correct { get; set; }
    public int InCorrect { get; set; }
    public double NetScore { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Status { get; set; }
}