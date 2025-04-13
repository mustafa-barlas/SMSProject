using SMS.DtoLayer.Student;
using StudentManagement.WebUI.Models;

namespace StudentManagement.WebUI.Services.Student;

public class StudentService(HttpClient httpClient) : IStudentService
{
    public async Task<List<StudentListDto>> GetAllStudentAsync()
    {
        var response = await httpClient.GetFromJsonAsync<GetAllStudentQueryResponse>("api/students");
        return response?.Students ?? new();
    }


    public async Task<StudentDetailDTO?> GetByIdStudentAsync(Guid studentId)
    {
        var response = await httpClient.GetAsync($"/api/students/{studentId}");
        return await response.Content.ReadFromJsonAsync<StudentDetailDTO>();
    }

    public async Task CreateStudentAsync(StudentCreateDTO dto)
    {
        var response = await httpClient.PostAsJsonAsync("/api/students", dto);
    }

    public async Task UpdateStudentAsync(StudentUpdateDTO dto)
    {
        var response = await httpClient.PutAsJsonAsync($"/api/students/{dto.Id}", dto);
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var response = await httpClient.DeleteAsync($"/api/students/{studentId}");
    }
}