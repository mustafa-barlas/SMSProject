using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class ExamResult : BaseEntity
{

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int ExamId { get; set; }
    public Exam Exam { get; set; }

    public int ModuleId { get; set; }
    public Module Module { get; set; }

    public int Correct { get; set; }
    public int Incorrect { get; set; }

    public double Total => Correct - (Incorrect / 4.0);
}