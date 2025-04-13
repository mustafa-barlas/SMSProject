using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.HomeWork;

public record HomeWorkDTO : BaseDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; }
}