using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class HomeWork : BaseEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public Guid? StudentId { get; set; }  // Ödevin sahibi öğrenci
    public Student? Student { get; set; }
}