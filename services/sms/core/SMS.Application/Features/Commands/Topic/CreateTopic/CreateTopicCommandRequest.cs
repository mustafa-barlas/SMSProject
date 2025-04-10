using MediatR;

namespace SMS.Application.Features.Commands.Topic.CreateTopic;

public class CreateTopicCommandRequest : IRequest<CreateTopicCommandResponse>
{
    public string? TopicName { get; set; }
    public Guid? ModuleId { get; set; }
    public bool Status { get; set; }
}