using SMS.DtoLayer.Topic;
using SMS.WebUI.ViewModels.Topic;

namespace SMS.WebUI.Services.Topic;

public interface ITopicService
{
    Task CreateTopicAsync(TopicCreateDto model);
    Task UpdateTopicAsync(TopicUpdateDto model);
    Task DeleteTopicAsync(int topicId);

    Task<List<TopicListViewModel>> GetAllTopicsByModuleIdAsync(int moduleId);
    Task<TopicViewModel> GetTopicByIdAsync(int topicId);
}