using MediatR;

namespace SMS.Application.Features.Queries.ExamResult.GetByIdExamResult;

public class GetExamResultByIdQueryRequest : IRequest<GetExamResultByIdQueryResponse>
{
    public int Id { get; set; }
}