using MediatR;

namespace SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;

public class GetHomeworksByStudentIdQueryRequest : IRequest<GetHomeworksByStudentIdQueryResponse>
{
    public int StudentId { get; set; }
}