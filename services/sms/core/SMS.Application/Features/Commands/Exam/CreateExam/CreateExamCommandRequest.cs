using MediatR;

namespace SMS.Application.Features.Commands.Exam.CreateExam;

public class CreateExamCommandRequest : IRequest<CreateExamCommandResponse>
{
    public string Title { get; set; }
    public DateTime ExamDate { get; set; }
}