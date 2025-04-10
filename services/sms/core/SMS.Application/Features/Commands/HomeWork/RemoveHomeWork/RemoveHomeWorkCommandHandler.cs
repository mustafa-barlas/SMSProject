using MediatR;
using SMS.Application.Repositories.HomeWorkRepository;

namespace SMS.Application.Features.Commands.HomeWork.RemoveHomeWork;

public class RemoveHomeWorkCommandHandler(IHomeWorkWriteRepository writeRepository): IRequestHandler<RemoveHomeWorkCommandRequest,RemoveHomeWorkCommandResponse>  
{
    public async Task<RemoveHomeWorkCommandResponse> Handle(RemoveHomeWorkCommandRequest request, CancellationToken cancellationToken)
    {
        await writeRepository.ChangeStatusAsync(request.HomeWorkId.ToString());
        await writeRepository.SaveAsync();
        return new RemoveHomeWorkCommandResponse();
    }
}