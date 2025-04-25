using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Exam;

public record ExamCreateDto : BaseDto
{
    public string Title { get; set; } 
    public DateTime ExamDate { get; set; }
}