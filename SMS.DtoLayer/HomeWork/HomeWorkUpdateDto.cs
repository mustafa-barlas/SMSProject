using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.HomeWork;

public record HomeWorkUpdateDto : BaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int StudentId { get; set; }
}