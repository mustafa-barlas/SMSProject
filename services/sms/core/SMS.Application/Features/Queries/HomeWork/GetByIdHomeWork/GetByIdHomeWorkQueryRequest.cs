using MediatR;

namespace SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;

public class GetByIdHomeWorkQueryRequest : IRequest<GetByIdHomeWorkQueryResponse>
{
    public Guid? HomeWorkId { get; set; }
}