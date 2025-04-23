using SMS.DtoLayer.Student;
using SMS.WebUI.ViewModels.Student;

namespace SMS.WebUI.Services.Student;

public interface IStudentService
{
    Task<List<StudentListViewModel>> GetAllStudentAsync();
    Task CreateStudentAsync(StudentCreateDto model);
    Task UpdateStudentAsync(StudentUpdateDto model);
    Task DeleteStudentAsync(int studentId);
    Task ChangeStudentAsync(int studentId, bool status);
    Task<StudentDetailViewModel?> GetByIdStudentAsync(int studentId);
}