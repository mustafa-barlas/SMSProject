using MediatR;

namespace SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;

public class GetHomeworkByIdQueryRequest : IRequest<GetHomeworkByIdQueryResponse>
{
    public int Id { get; set; }
}