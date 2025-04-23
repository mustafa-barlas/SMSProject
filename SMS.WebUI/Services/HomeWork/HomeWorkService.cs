using SMS.DtoLayer.HomeWork;
using SMS.WebUI.ViewModels.Homework;

namespace SMS.WebUI.Services.HomeWork;

public class HomeWorkService(HttpClient httpClient) : IHomeWorkService
{
    public async Task<List<HomeWorkViewModel>> GetAllHomeworkByStudentId(int studentId)
    {
        var response = await httpClient.GetFromJsonAsync<List<HomeWorkViewModel>>($"homeWorks/student/{studentId}");
        return response ?? new();
    }

    public async Task<HomeWorkViewModel?> GetByIdAsync(int id)
    {
        var response = await httpClient.GetAsync($"homeWorks/{id}");
        return await response.Content.ReadFromJsonAsync<HomeWorkViewModel>();
    }

    public async Task CreateAsync(HomeWorkCreateDto model)
    {
        await httpClient.PostAsJsonAsync("homeWorks", model);
    }

    public async Task UpdateAsync(HomeWorkUpdateDto model)
    {
        await httpClient.PutAsJsonAsync($"homeWorks/{model.Id}", model);
    }


    public async Task DeleteAsync(int id)
    {
        await httpClient.DeleteAsync($"homeWorks/{id}");
    }
}