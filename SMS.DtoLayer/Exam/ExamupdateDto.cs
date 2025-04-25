using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Exam;

public record ExamupdateDto : BaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ExamDate { get; set; }
}