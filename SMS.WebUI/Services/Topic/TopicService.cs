using SMS.DtoLayer.Topic;

namespace SMS.WebUI.Services.Topic;

public class TopicService(HttpClient httpClient) : ITopicService
{
    public async Task CreateTopicAsync(TopicCreateDto topicCreateDto)
    {
        await httpClient.PostAsJsonAsync("topics", topicCreateDto);
    }

    public async Task UpdateTopicAsync(TopicUpdateDto topicUpdateDto)
    {
        await httpClient.PutAsJsonAsync($"topics/{topicUpdateDto.Id}", topicUpdateDto);
    }

    public async Task DeleteTopicAsync(Guid topicId)
    {
        await httpClient.DeleteAsync($"topics/{topicId}");
    }

    public async Task<List<TopicDto>> GetAllTopicsAsync(bool includeModule = false)
    {
        string url = $"topics?IncludeModule={includeModule.ToString().ToLower()}";

        var response = await httpClient.GetFromJsonAsync<TopicListDto>(url);
        return response?.Topics ?? new();
    }

    public async Task<List<TopicDto>> GetAllTopicsWithModuleIdAsync(Guid moduleId)
    {
        var response = await httpClient.GetFromJsonAsync<TopicListDto>($"topics/{moduleId}");
        return response?.Topics ?? new();
    }

    public async Task<TopicDto?> GetTopicByIdAsync(Guid topicId)
    {
        var response = await httpClient.GetAsync($"topics/{topicId}");
        return await response.Content.ReadFromJsonAsync<TopicDto>();
    }
}