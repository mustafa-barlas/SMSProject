using MediatR;

namespace SMS.Application.Features.Queries.ExamResult.GetExamResultByStudentId
{
    public class GetExamResultsByStudentIdQueryRequest : IRequest<GetExamResultsByStudentIdQueryResponse>
    {
        public int StudentId { get; set; }
    }
}