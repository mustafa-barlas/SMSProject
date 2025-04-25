using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ExamRepository;

namespace SMS.Application.Features.Commands.Exam.UpdateExam;

public class UpdateExamCommandHandler(
    IExamReadRepository readRepository,
    IExamWriteRepository writeRepository,
    IMapper mapper)
    : IRequestHandler<UpdateExamCommandRequest, UpdateExamCommandResponse>
{
    public async Task<UpdateExamCommandResponse> Handle(UpdateExamCommandRequest request,
        CancellationToken cancellationToken)
    {
        var exam = await readRepository.GetByIdAsync(request.Id);
        if (exam == null) throw new Exception("Exam not found");

        mapper.Map(request, exam);

        await writeRepository.SaveAsync();

        return new();
    }
}