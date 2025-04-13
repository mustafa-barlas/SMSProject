using MediatR;
using SMS.Application.Repositories.TopicRepository;

namespace SMS.Application.Features.Commands.Topic.UpdateTopic;

public class UpdateTopicCommandHandler(ITopicWriteRepository writeRepository, ITopicReadRepository readRepository)
    : IRequestHandler<UpdateTopicCommandRequest, UpdateTopicCommandResponse>
{
    public async Task<UpdateTopicCommandResponse> Handle(UpdateTopicCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await readRepository.GetByIdAsync(request.TopicId.ToString());
        response.Name = request.TopicName;
        response.UpdatedDate = DateTime.Now;
        response.ModuleId = request.ModuleId;
        response.Status = request.Status;

        await writeRepository.SaveAsync();
        return new UpdateTopicCommandResponse();
    }
}