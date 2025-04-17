using MediatR;
using SMS.Application.Repositories.TopicRepository;

namespace SMS.Application.Features.Commands.Topic.RemoveTopic;

public class RemoveTopicCommandHandler(ITopicWriteRepository writeRepository)
    : IRequestHandler<RemoveTopicCommandRequest, RemoveTopicCommandResponse>
{
    public async Task<RemoveTopicCommandResponse> Handle(RemoveTopicCommandRequest request,
        CancellationToken cancellationToken)
    {
        await writeRepository.ChangeStatusAsync(request.Id.ToString());
        return new RemoveTopicCommandResponse();
    }
}