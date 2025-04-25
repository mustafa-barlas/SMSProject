using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.ExamResult;

public record ExamResultListDto : BaseDto
{
    public int Id { get; init; } 
    public int StudentId { get; init; } 
    public int ExamId { get; init; } 
    public int ModuleId { get; init; } 
    public int Correct { get; init; } 
    public int InCorrect { get; init; } 
    public double NetScore { get; init; } 
}
