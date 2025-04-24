using AutoMapper;
using SMS.Application.Features.Commands.Topic.CreateTopic;
using SMS.Domain.Entities;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Mappings;

public class TopicMappingProfile : Profile
{
    public TopicMappingProfile()
    {
        CreateMap<Topic, GetAllTopicDto>().ReverseMap();
        CreateMap<Topic, TopicCreateDto>().ReverseMap();
        CreateMap<CreateTopicCommandRequest, TopicCreateDto>().ReverseMap();
        CreateMap<CreateTopicCommandRequest, Topic>().ReverseMap();
        CreateMap<Topic, TopicGetByIdDto>().ReverseMap();
        CreateMap<Topic, TopicUpdateDto>().ReverseMap();
    }
}