using MediatR;
using SMS.Application.Repositories.HomeWorkRepository;

namespace SMS.Application.Features.Commands.HomeWork.UpdateHomeWork;

public class UpdateHomeWorkCommandHandler(IHomeWorkWriteRepository writeRepository,IHomeWorkReadRepository readRepository) : IRequestHandler<UpdateHomeWorkCommandRequest,UpdateHomeWorkCommandResponse>
{
    public async Task<UpdateHomeWorkCommandResponse> Handle(UpdateHomeWorkCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await readRepository.GetByIdAsync(request.HomeWorkId.ToString());
        
        response.Content = request.Content;
        response.Status = request.Status;
        response.StudentId = request.StudentId;
        response.UpdatedDate = DateTime.Now;
        response.Title = request.Title;
        
        await writeRepository.SaveAsync();
        
        return new();
    }
}