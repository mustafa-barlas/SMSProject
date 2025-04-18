using MediatR;
using SMS.Application.Repositories.TopicRepository;

namespace SMS.Application.Features.Commands.Topic.RemoveTopic;

public class RemoveTopicCommandHandler(ITopicWriteRepository writeRepository, ITopicReadRepository readRepository)
    : IRequestHandler<RemoveTopicCommandRequest, RemoveTopicCommandResponse>
{
    public async Task<RemoveTopicCommandResponse> Handle(RemoveTopicCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await readRepository.GetByIdAsync(request.Id);
        writeRepository.Remove(response);
        await writeRepository.SaveAsync();
        return new RemoveTopicCommandResponse();
    }
}