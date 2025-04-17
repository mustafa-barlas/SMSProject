using SMS.DtoLayer.Student;

namespace SMS.WebUI.Models;

public class GetAllStudentQueryResponse
{
    public List<GetAllStudentDto>? Students { get; set; }
}
