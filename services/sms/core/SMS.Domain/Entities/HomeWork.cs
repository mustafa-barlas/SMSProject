using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class HomeWork : BaseEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool? Status { get; set; }
}