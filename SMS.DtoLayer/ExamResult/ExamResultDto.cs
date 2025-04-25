using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.ExamResult;

public record ExamResultDto : BaseDto
{
    public int Id { get; init; }

    public int StudentId { get; init; }
    public string StudentName { get; init; }

    public int ExamId { get; init; }
    public string ExamTitle { get; init; }

    public int ModuleId { get; init; }
    public string ModuleTitle { get; init; }

    public int Correct { get; init; }
    public int InCorrect { get; init; }
    public double NetScore { get; init; }
}