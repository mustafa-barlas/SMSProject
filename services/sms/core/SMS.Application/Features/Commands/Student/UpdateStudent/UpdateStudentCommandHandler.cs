using MediatR;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Commands.Student.UpdateStudent;

public class UpdateStudentCommandHandler(IStudentReadRepository readRepository, IStudentWriteRepository writeRepository)
    : IRequestHandler<UpdateStudentCommandRequest, UpdateStudentCommandResponse>
{
    public async Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommandRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Student student = await readRepository.GetByIdAsync(request.StudentId);

        student.Name = request.Name;
        student.Age = request.Age;
        student.Status = request.Status;
        student.UpdatedDate = DateTime.Now;

        await writeRepository.SaveAsync();
        return new();
    }
}