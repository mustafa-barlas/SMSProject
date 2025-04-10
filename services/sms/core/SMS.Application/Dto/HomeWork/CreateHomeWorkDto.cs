namespace SMS.Application.Dto.HomeWork;

public class CreateHomeWorkDto
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool Status { get; set; }

    public string? StudentId { get; set; }
}