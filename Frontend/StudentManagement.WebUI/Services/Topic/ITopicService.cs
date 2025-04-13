using SMS.DtoLayer.Topic;

namespace StudentManagement.WebUI.Services.Topic;

public interface ITopicService
{
    Task CreateTopicAsync(TopicCreateDTO topicCreateDto);
    Task UpdateTopicAsync(TopicUpdateDTO topicUpdateDto);
    Task DeleteTopicAsync(Guid topicId);

    Task<List<TopicDto>> GetAllTopicsAsync(bool includeModule = false);
    Task<List<TopicDto>> GetAllTopicsWithModuleIdAsync(Guid moduleId);
    Task<TopicDto?> GetTopicByIdAsync(Guid topicId);
}