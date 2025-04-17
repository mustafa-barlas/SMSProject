using MediatR;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Commands.Topic.UpdateTopic;

public class UpdateTopicCommandRequest : IRequest<UpdateTopicCommandResponse>
{
    public TopicUpdateDto  TopicUpdateDto { get; set; }
}