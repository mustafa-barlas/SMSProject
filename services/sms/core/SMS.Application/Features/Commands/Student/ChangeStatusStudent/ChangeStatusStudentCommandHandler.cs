using MediatR;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Commands.Student.ChangeStatusStudent;

public class ChangeStatusStudentCommandHandler(IStudentWriteRepository writeRepository)
    : IRequestHandler<ChangeStatusStudentCommandRequest,
        ChangeStatusStudentCommandResponse>
{
    public async Task<ChangeStatusStudentCommandResponse> Handle(ChangeStatusStudentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await writeRepository.ChangeStatusAsync(request.Id, request.Status);
        await writeRepository.SaveAsync();
        return new();
    }
}