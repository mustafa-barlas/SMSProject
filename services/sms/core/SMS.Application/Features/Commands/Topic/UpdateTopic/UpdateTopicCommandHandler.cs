using AutoMapper;
using MediatR;
using SMS.Application.Repositories.TopicRepository;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Commands.Topic.UpdateTopic;

public class UpdateTopicCommandHandler(
    ITopicWriteRepository writeRepository,
    ITopicReadRepository readRepository,
    IMapper mapper)
    : IRequestHandler<UpdateTopicCommandRequest, UpdateTopicCommandResponse>
{
    public async Task<UpdateTopicCommandResponse> Handle(UpdateTopicCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await readRepository.GetByIdAsync(request.TopicUpdateDto.Id);
        mapper.Map(request.TopicUpdateDto, response);
        writeRepository.Update(response);
        await writeRepository.SaveAsync();
        return new UpdateTopicCommandResponse();
    }
}