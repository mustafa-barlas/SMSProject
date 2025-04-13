using SMS.DtoLayer.HomeWork;

namespace StudentManagement.WebUI.Services.HomeWork;

public class HomeWorkService(HttpClient httpClient) : IHomeWorkService
{
    public async Task<List<HomeworkListDto>> GetHomeworksByStudentIdAsync(Guid studentId)
    {
        var response = await httpClient.GetFromJsonAsync<List<HomeworkListDto>>($"/api/homeworks/{studentId}");
        return response ?? new();
    }

    public async Task<HomeworkListDto?> GetByIdAsync(Guid id)
    {
        var response = await httpClient.GetAsync($"/api/homeworks/{id}");
        return await response.Content.ReadFromJsonAsync<HomeworkListDto>();
    }

    public async Task CreateAsync(HomeWorkCreateDTO dto)
    {
        await httpClient.PostAsJsonAsync("/api/homeworks", dto);
    }

    public async Task UpdateAsync(HomeWorkUpdateDTO dto)
    {
        await httpClient.PutAsJsonAsync($"/api/homeworks/{dto.Id}", dto);
    }

    public async Task DeleteAsync(Guid id)
    {
        await httpClient.DeleteAsync($"/api/homeworks/{id}");
    }
}