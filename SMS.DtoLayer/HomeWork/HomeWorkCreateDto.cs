using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.HomeWork;

public record HomeWorkCreateDto  : BaseDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int StudentId { get; set; }
    
    public DateTime DueDate { get; set; }

    public bool Status { get; set; }
    public bool IsFinished { get; set; }
}