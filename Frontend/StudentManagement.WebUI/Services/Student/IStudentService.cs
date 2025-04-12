using SMS.DtoLayer.Student;

namespace StudentManagement.WebUI.Services.Student;

public interface IStudentService
{
    Task<List<StudentListDTO>> GetAllStudentAsync();
    Task CreateStudentAsync(StudentCreateDTO studentCreateDto);
    Task UpdateStudentAsync(StudentUpdateDTO studentUpdateDto);
    Task DeleteStudentAsync(Guid studentId);
    Task<StudentDetailDTO> GetByIdStudentAsync(Guid studentId);
}