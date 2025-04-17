using SMS.DtoLayer.HomeWork;

namespace SMS.WebUI.Services.HomeWork;

public class HomeWorkService(HttpClient httpClient) : IHomeWorkService
{
    public async Task<List<HomeworkListDto>> GetHomeworksByStudentIdAsync(Guid studentId)
    {
        var response = await httpClient.GetFromJsonAsync<List<HomeworkListDto>>($"homeworks/{studentId}");
        return response ?? new();
    }

    public async Task<HomeworkListDto?> GetByIdAsync(Guid id)
    {
        var response = await httpClient.GetAsync($"homeworks/{id}");
        return await response.Content.ReadFromJsonAsync<HomeworkListDto>();
    }

    public async Task CreateAsync(HomeWorkCreateDTO dto)
    {
        await httpClient.PostAsJsonAsync("homeworks", dto);
    }

    public async Task UpdateAsync(HomeWorkUpdateDto dto)
    {
        await httpClient.PutAsJsonAsync($"homeworks/{dto.Id}", dto);
    }

    public async Task DeleteAsync(Guid id)
    {
        await httpClient.DeleteAsync($"homeworks/{id}");
    }
}