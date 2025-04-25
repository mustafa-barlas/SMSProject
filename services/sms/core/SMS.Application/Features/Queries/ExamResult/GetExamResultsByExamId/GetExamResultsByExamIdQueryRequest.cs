using MediatR;

namespace SMS.Application.Features.Queries.ExamResult.GetExamResultsByExamId;

public class GetExamResultsByExamIdQueryRequest : IRequest<GetExamResultsByExamIdQueryResponse>
{
    public int ExamId { get; set; }
    public int StudentId { get; set; }
}