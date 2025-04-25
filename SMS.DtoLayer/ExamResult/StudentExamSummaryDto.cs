namespace SMS.DtoLayer.ExamResult;

public class StudentExamSummaryDto
{
    public string StudentName { get; set; } = null!;
    public string ExamTitle { get; set; } = null!;
    public List<ExamResultDto> Results { get; set; } = new List<ExamResultDto>();
    public double TotalNet { get; set; }
}