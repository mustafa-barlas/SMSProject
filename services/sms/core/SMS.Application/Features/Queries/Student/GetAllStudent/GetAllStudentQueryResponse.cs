using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Queries.Student.GetAllStudent;

public class GetAllStudentQueryResponse
{
    public List<StudentListDto>? Students { get; set; }
}