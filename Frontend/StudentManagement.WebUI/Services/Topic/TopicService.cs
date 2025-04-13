using SMS.DtoLayer.Topic;

namespace StudentManagement.WebUI.Services.Topic;

public class TopicService(HttpClient httpClient) : ITopicService
{
    public async Task CreateTopicAsync(TopicCreateDTO topicCreateDto)
    {
        await httpClient.PostAsJsonAsync("/api/topics", topicCreateDto);
    }

    public async Task UpdateTopicAsync(TopicUpdateDTO topicUpdateDto)
    {
        await httpClient.PutAsJsonAsync($"/api/topics/{topicUpdateDto.Id}", topicUpdateDto);
    }

    public async Task DeleteTopicAsync(Guid topicId)
    {
        await httpClient.DeleteAsync($"/api/topics/{topicId}");
    }

    public async Task<List<TopicDto>> GetAllTopicsAsync(bool includeModule = false)
    {
        string url = $"api/topics?IncludeModule={includeModule.ToString().ToLower()}";

        var response = await httpClient.GetFromJsonAsync<TopicListDto>(url);
        return response?.Topics ?? new();
    }

    public async Task<List<TopicDto>> GetAllTopicsWithModuleIdAsync(Guid moduleId)
    {
        var response = await httpClient.GetFromJsonAsync<TopicListDto>($"api/topics/{moduleId}");
        return response?.Topics ?? new();
    }

    public async Task<TopicDto?> GetTopicByIdAsync(Guid topicId)
    {
        var response = await httpClient.GetAsync($"/api/topics/{topicId}");
        return await response.Content.ReadFromJsonAsync<TopicDto>();
    }
}