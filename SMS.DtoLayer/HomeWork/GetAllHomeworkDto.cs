namespace SMS.DtoLayer.HomeWork;

public class GetAllHomeworkDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int StudentId { get; set; }

    public DateTime DueDate { get; set; }
    public DateTime CreatedDate { get; set; }

    public bool Status { get; set; }
    public bool IsFinished { get; set; }
}