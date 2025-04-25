using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.ExamResult;

public record ExamResultListDto : BaseDto
{
    public int Id { get; init; } // Kimlik
    public int StudentId { get; init; } // Öğrenci kimliği
    public int ExamId { get; init; } // Sınav kimliği
    public int ModuleId { get; init; } // Modül kimliği
    public int Correct { get; init; } // Doğru sayısı
    public int Incorrect { get; init; } // Yanlış sayısı
    public double NetScore { get; init; } // Hesaplanmış net (örn. doğru – yanlış/4)
}