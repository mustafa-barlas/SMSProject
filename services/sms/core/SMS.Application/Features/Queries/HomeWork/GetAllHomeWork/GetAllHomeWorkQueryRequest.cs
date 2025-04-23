using MediatR;

namespace SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;

public class GetAllHomeWorkQueryRequest : IRequest<GetAllHomeWorkQueryResponse>
{
    public int StudentId { get; set; }
}