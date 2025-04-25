using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.ExamResult;

public record ExamResultCreateDto : BaseDto
{
    public int StudentId { get; set; }
    public int ExamId { get; set; }
    public int ModuleId { get; set; } // Hangi derse ait?
    public int Correct { get; set; }
    public int InCorrect { get; set; }
}