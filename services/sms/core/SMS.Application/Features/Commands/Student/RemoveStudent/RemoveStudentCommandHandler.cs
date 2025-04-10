using MediatR;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Commands.Student.RemoveStudent;

public class RemoveStudentCommandHandler(IStudentWriteRepository writeRepository) : IRequestHandler<RemoveStudentCommandRequest, RemoveStudentCommandResponse>
{
    public async Task<RemoveStudentCommandResponse> Handle(RemoveStudentCommandRequest request, CancellationToken cancellationToken)
    {
        await writeRepository.RemoveByIdAsync(request.StudentId);
        await writeRepository.SaveAsync();

        return new();
    }
}