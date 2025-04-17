using SMS.DtoLayer.Student;

namespace SMS.WebUI.Services.Student;

public interface IStudentService
{
    Task<List<GetAllStudentDto>> GetAllStudentAsync();
    Task CreateStudentAsync(StudentCreateDto studentCreateDto);
    Task UpdateStudentAsync(StudentUpdateDto studentUpdateDto);
    Task DeleteStudentAsync(Guid studentId);
    Task<StudentDetailDTO?> GetByIdStudentAsync(Guid studentId);
    Task<StudentDetailDTO?> GetStudentWithAllFieldAsync(Guid studentId);
}