using SMS.DtoLayer.Topic;

namespace SMS.WebUI.Services.Topic;

public interface ITopicService
{
    Task CreateTopicAsync(TopicCreateDto topicCreateDto);
    Task UpdateTopicAsync(TopicUpdateDto topicUpdateDto);
    Task DeleteTopicAsync(Guid topicId);

    Task<List<TopicDto>> GetAllTopicsAsync(bool includeModule = false);
    Task<List<TopicDto>> GetAllTopicsWithModuleIdAsync(Guid moduleId);
    Task<TopicDto?> GetTopicByIdAsync(Guid topicId);
}