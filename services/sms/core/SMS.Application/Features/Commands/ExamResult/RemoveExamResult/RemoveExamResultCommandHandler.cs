using MediatR;
using SMS.Application.Repositories.ExamResultRepository;

namespace SMS.Application.Features.Commands.ExamResult.RemoveExamResult;

public class RemoveExamResultCommandHandler(
    IExamResultReadRepository readRepository,
    IExamResultWriteRepository writeRepository)
    : IRequestHandler<RemoveExamResultCommandRequest, RemoveExamResultCommandResponse>
{
    public async Task<RemoveExamResultCommandResponse> Handle(RemoveExamResultCommandRequest request,
        CancellationToken cancellationToken)
    {
        var examResult = await readRepository.GetByIdAsync(request.Id);

        writeRepository.Remove(examResult);
        await writeRepository.SaveAsync();

        return new RemoveExamResultCommandResponse();
    }
}