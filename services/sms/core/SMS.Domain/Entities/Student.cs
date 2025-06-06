using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }

    public List<StudentModule> StudentModules { get; set; } = new List<StudentModule>();
    public List<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();
    public ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
}