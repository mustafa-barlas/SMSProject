using MediatR;

namespace SMS.Application.Features.Commands.ExamResult.CreateExamResult;

public class CreateExamResultCommandRequest : IRequest<CreateExamResultCommandResponse>
{
    public int StudentId { get; set; }
    public int ExamId { get; set; }
    public int ModuleId { get; set; }
    public int Correct { get; set; }
    public int InCorrect { get; set; }
}
