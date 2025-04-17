using AutoMapper;
using SMS.Domain.Entities;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Mappings;

public class TopicMappingProfile : Profile
{
    public TopicMappingProfile()
    {
        CreateMap<Topic, GetAllTopicDto>().ReverseMap();
        CreateMap<Topic, TopicCreateDto>().ReverseMap();
        CreateMap<Topic, TopicGetByIdDto>().ReverseMap();
        CreateMap<Topic, TopicUpdateDto>().ReverseMap();
    }
}