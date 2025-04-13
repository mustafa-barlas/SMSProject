using SMS.DtoLayer.Base;
using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.Module;

namespace SMS.DtoLayer.Student;

public record StudentListDto : BaseDTO
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? DateOfBirth { get; set; }
}