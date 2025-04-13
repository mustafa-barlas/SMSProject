using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.HomeWork;

public record HomeWorkCreateDTO : BaseDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public Guid StudentId { get; set; }
}