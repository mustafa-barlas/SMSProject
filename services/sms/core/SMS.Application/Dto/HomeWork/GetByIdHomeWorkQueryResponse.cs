using SMS.Application.Dto.Student;

namespace SMS.Application.Dto.HomeWork;

public class GetByIdHomeWorkQueryResponse
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public StudentDto? Student { get; set; }
}