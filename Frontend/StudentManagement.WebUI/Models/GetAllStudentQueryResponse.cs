using SMS.DtoLayer.Student;

namespace StudentManagement.WebUI.Models;

public class GetAllStudentQueryResponse
{
    public List<StudentListDto>? Students { get; set; }
}
