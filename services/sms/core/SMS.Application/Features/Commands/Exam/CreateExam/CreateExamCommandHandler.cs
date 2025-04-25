using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ExamRepository;

namespace SMS.Application.Features.Commands.Exam.CreateExam;

public class CreateExamCommandHandler(IExamWriteRepository writeRepository, IMapper mapper) : IRequestHandler<CreateExamCommandRequest, CreateExamCommandResponse>
{
    public async Task<CreateExamCommandResponse> Handle(CreateExamCommandRequest request,
        CancellationToken cancellationToken)
    {
        var exam = mapper.Map<Domain.Entities.Exam>(request);
        await writeRepository.AddAsync(exam);
        await writeRepository.SaveAsync();
        return new();
    }
}