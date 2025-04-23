using AutoMapper;
using SMS.DtoLayer.Student;
using SMS.WebUI.Models;
using SMS.WebUI.ViewModels.Student;

namespace SMS.WebUI.Services.Student;

public class StudentService(HttpClient httpClient, IMapper mapper) : IStudentService
{
    public async Task<List<StudentListViewModel>> GetAllStudentAsync()
    {
        var response = await httpClient.GetFromJsonAsync<StudentListResponseViewModel>("students");
        return response.Students;
    }

    public async Task<StudentDetailViewModel?> GetByIdStudentAsync(int studentId)
    {
        var response = await httpClient.GetAsync($"students/{studentId}");
        var data = await response.Content.ReadFromJsonAsync<GetAllStudentQueryResponse>();
        return data.Student; // çünkü JSON'da ana key "student"
    }
    //
    // public async Task<StudentDetailViewModel?> GetByIdStudentAsync(int studentId)
    // {
    //     var response = await httpClient.GetAsync($"students/{studentId}");
    //     return await response.Content.ReadFromJsonAsync<StudentDetailViewModel>();
    // }


    public async Task CreateStudentAsync(StudentCreateDto model)
    {
        await httpClient.PostAsJsonAsync("Students/create", model);
    }

    public async Task UpdateStudentAsync(StudentUpdateDto model)
    {
        // await httpClient.PutAsJsonAsync("students", model);
        await httpClient.PutAsJsonAsync("students/update", model); // Tam endpoint yolunu belirti
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        await httpClient.DeleteAsync($"students/{studentId}");
    }

    public async Task ChangeStudentAsync(int studentId, bool status)
    {
        await httpClient.PutAsJsonAsync($"students/{studentId}/status", new { Status = status });
    }
}