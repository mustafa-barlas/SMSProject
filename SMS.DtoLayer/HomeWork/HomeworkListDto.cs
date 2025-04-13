namespace SMS.DtoLayer.HomeWork;

public class HomeworkListDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool Status { get; set; }
    public Guid StudentId { get; set; }
}