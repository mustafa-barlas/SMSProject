using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Exam : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public ICollection<ExamResult> ExamResults { get; set; }
}