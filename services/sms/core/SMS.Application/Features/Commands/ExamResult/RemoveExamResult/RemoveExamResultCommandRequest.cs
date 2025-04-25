using MediatR;

namespace SMS.Application.Features.Commands.ExamResult.RemoveExamResult;

public class RemoveExamResultCommandRequest : IRequest<RemoveExamResultCommandResponse>
{
    public int Id { get; set; }
}