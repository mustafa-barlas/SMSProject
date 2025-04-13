using MediatR;

namespace SMS.Application.Features.Commands.Topic.UpdateTopic;

public class UpdateTopicCommandRequest : IRequest<UpdateTopicCommandResponse>
{
    public Guid TopicId { get; set; }
    public string? TopicName { get; set; }
    public Guid ModuleId { get; set; }
    public bool Status { get; set; }
}