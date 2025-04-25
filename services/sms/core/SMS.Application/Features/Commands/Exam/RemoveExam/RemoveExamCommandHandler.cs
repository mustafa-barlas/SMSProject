using MediatR;
using SMS.Application.Repositories.ExamRepository;

namespace SMS.Application.Features.Commands.Exam.RemoveExam;

public class RemoveExamCommandHandler(IExamWriteRepository writeRepository, IExamReadRepository readRepository) 
    : IRequestHandler<RemoveExamCommandRequest, RemoveExamCommandResponse>
{
    public async Task<RemoveExamCommandResponse> Handle(RemoveExamCommandRequest request, CancellationToken cancellationToken)
    {
        var exam = await readRepository.GetByIdAsync(request.Id);
        if (exam == null) throw new Exception("Exam not found");

        writeRepository.Remove(exam);
        await writeRepository.SaveAsync();

        return new();
    }
}