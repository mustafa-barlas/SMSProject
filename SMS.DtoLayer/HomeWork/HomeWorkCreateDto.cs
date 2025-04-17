using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.HomeWork;

public record HomeWorkCreateDto : BaseDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int StudentId { get; set; }
}