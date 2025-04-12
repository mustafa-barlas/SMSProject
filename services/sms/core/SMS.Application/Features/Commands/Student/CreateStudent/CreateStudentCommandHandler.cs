using MediatR;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Commands.Student.CreateStudent;

public class CreateStudentCommandHandler(IStudentWriteRepository studentWriteRepository)  : IRequestHandler<CreateStudentCommandRequest,CreateStudentCommandResponse>
{
    public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
    {
        await studentWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            ImageUrl = request.ImageUrl,
            Status = request.Status,
        });

        await studentWriteRepository.SaveAsync();
        return new();
    }
}