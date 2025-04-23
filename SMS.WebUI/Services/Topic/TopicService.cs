using SMS.DtoLayer.Topic;
using SMS.WebUI.ViewModels.Topic;

namespace SMS.WebUI.Services.Topic;

public class TopicService(HttpClient httpClient) : ITopicService
{
    public async Task CreateTopicAsync(TopicCreateDto model)
    {
        await httpClient.PostAsJsonAsync("topics/create", model);
    }

    public async Task UpdateTopicAsync(TopicUpdateDto model)
    {
        await httpClient.PutAsJsonAsync("topics/update", model);
    }

    public async Task DeleteTopicAsync(int topicId)
    {
        await httpClient.DeleteAsync($"topics/{topicId}");
    }

    public async Task<List<TopicListViewModel>> GetAllTopicsAsync()
    {
        var response = await httpClient.GetFromJsonAsync<List<TopicListViewModel>>("topics");
        return response;
    }

    public async Task<TopicViewModel> GetTopicByIdAsync(int topicId)
    {
        var response = await httpClient.GetAsync($"topics/{topicId}");
        return await response.Content.ReadFromJsonAsync<TopicViewModel>();
    }
}