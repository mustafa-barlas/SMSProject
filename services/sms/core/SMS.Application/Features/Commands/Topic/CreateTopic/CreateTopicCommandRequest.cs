using MediatR;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Commands.Topic.CreateTopic;

public class CreateTopicCommandRequest : IRequest<CreateTopicCommandResponse>
{
    public TopicCreateDto TopicCreateDto { get; set; }
}