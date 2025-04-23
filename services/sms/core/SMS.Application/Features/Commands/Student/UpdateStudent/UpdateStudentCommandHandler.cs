using AutoMapper;
using MediatR;
using SMS.Application.Repositories.StudentRepository;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Commands.Student.UpdateStudent;

public class UpdateStudentCommandHandler(
    IStudentReadRepository readRepository,
    IStudentWriteRepository writeRepository,
    IMapper mapper)
    : IRequestHandler<UpdateStudentCommandRequest, UpdateStudentCommandResponse>
{
    public async Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var student = await readRepository.GetByIdAsync(request.Id);

        mapper.Map(request, student); // CommandRequest → Entity

        writeRepository.Update(student);
        await writeRepository.SaveAsync();

        return new();
    }
}