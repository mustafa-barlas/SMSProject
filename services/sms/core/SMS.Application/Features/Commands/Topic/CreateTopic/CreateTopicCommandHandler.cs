using MediatR;
using SMS.Application.Repositories.TopicRepository;

namespace SMS.Application.Features.Commands.Topic.CreateTopic;

public class CreateTopicCommandHandler(ITopicWriteRepository writeRepository)
    : IRequestHandler<CreateTopicCommandRequest, CreateTopicCommandResponse>
{
    public async Task<CreateTopicCommandResponse> Handle(CreateTopicCommandRequest request,
        CancellationToken cancellationToken)
    {
        await writeRepository.AddAsync(new()
        {
            Name = request.TopicName,
            ModuleId = request.ModuleId,
            Status = request.Status,
        });
        await writeRepository.SaveAsync();
        return new CreateTopicCommandResponse();
    }
}