using AutoMapper;
using MediatR;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Commands.Student.CreateStudent;

public class CreateStudentCommandHandler(IStudentWriteRepository studentWriteRepository, IMapper mapper)
    : IRequestHandler<CreateStudentCommandRequest, CreateStudentCommandResponse>
{
    public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var student = mapper.Map<Domain.Entities.Student>(request.StudentCreateDto);
        await studentWriteRepository.AddAsync(student);

        await studentWriteRepository.SaveAsync();
        return new();
    }
}