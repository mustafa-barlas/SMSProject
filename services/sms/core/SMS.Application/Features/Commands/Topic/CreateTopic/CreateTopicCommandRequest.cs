using MediatR;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Commands.Topic.CreateTopic;

public class CreateTopicCommandRequest : IRequest<CreateTopicCommandResponse>
{
    public string Title { get; set; }
    public int ModuleId { get; set; }
    public bool Status { get; set; }
}