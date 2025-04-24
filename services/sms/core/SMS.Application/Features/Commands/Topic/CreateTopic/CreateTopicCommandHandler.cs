using AutoMapper;
using MediatR;
using SMS.Application.Repositories.TopicRepository;

namespace SMS.Application.Features.Commands.Topic.CreateTopic;

public class CreateTopicCommandHandler(ITopicWriteRepository writeRepository, IMapper mapper)
    : IRequestHandler<CreateTopicCommandRequest, CreateTopicCommandResponse>
{
    public async Task<CreateTopicCommandResponse> Handle(CreateTopicCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = mapper.Map<Domain.Entities.Topic>(request);

        await writeRepository.AddAsync(response);
        await writeRepository.SaveAsync();
        return new CreateTopicCommandResponse();
    }
}