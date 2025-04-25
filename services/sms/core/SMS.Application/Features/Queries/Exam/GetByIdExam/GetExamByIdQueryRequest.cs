using MediatR;

namespace SMS.Application.Features.Queries.Exam.GetByIdExam
{
    public class GetExamByIdQueryRequest : IRequest<GetExamByIdQueryResponse>
    {
        public int Id { get; set; } // Sınavın ID'si
    }
}