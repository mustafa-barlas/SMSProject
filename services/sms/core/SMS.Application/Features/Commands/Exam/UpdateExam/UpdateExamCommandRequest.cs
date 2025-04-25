using MediatR;

namespace SMS.Application.Features.Commands.Exam.UpdateExam;

public class UpdateExamCommandRequest : IRequest<UpdateExamCommandResponse>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ExamDate { get; set; }
}