using MediatR;

namespace SMS.Application.Features.Commands.Topic.RemoveTopic;

public class RemoveTopicCommandRequest : IRequest<RemoveTopicCommandResponse>
{
    public int Id { get; set; }
}