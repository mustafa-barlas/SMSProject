using MediatR;
using SMS.Application.Dto.HomeWork;
using SMS.Application.Repositories.HomeWorkRepository;

namespace SMS.Application.Features.Commands.HomeWork.CreateHomeWork;

public class CreateHomeWorkCommandHandler(IHomeWorkWriteRepository writeRepository)
    : IRequestHandler<CreateHomeWorkCommandRequest, CreateHomeWorkCommandResponse>
{
    public async Task<CreateHomeWorkCommandResponse> Handle(CreateHomeWorkCommandRequest request,
        CancellationToken cancellationToken)
    {
        await writeRepository.AddAsync(new()
        {
            Content = request.Content,
            Title = request.Title,
            Status = request.Status,
            StudentId = request.StudentId,
        });
        await writeRepository.SaveAsync();
        return new();
    }
}