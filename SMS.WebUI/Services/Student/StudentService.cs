using SMS.DtoLayer.Student;
using SMS.WebUI.Models;

namespace SMS.WebUI.Services.Student;

public class StudentService(HttpClient httpClient) : IStudentService
{
    public async Task<List<GetAllStudentDto>> GetAllStudentAsync()
    {
        var response = await httpClient.GetFromJsonAsync<GetAllStudentQueryResponse>("students");
        return response?.Students ?? new();
    }


    public async Task<StudentDetailDTO?> GetByIdStudentAsync(Guid studentId)
    {
        var response = await httpClient.GetAsync($"students/{studentId}");
        return await response.Content.ReadFromJsonAsync<StudentDetailDTO>();
    }

    public async Task<StudentDetailDTO?> GetStudentWithAllFieldAsync(Guid studentId)
    {
        var response = await httpClient.GetAsync($"students/{studentId}/all"); // Adjust the endpoint if necessary
        return await response.Content.ReadFromJsonAsync<StudentDetailDTO>();
    }


    public async Task CreateStudentAsync(StudentCreateDto dto)
    {
        var response = await httpClient.PostAsJsonAsync("students", dto);
    }

    public async Task UpdateStudentAsync(StudentUpdateDto dto)
    {
        // var response = await httpClient.PutAsJsonAsync($"students/{dto.Id}", dto);
        var response = await httpClient.PutAsJsonAsync("students",dto);
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var response = await httpClient.DeleteAsync($"students/{studentId}");
    }
}