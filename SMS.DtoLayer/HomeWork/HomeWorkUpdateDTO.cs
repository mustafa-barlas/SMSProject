namespace SMS.DtoLayer.HomeWork;

public class HomeWorkUpdateDTO
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public Guid? StudentId { get; set; }
}