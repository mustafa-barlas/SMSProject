using MediatR;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent;

public class GetByIdStudentQueryRequest : IRequest<GetByIdStudentQueryResponse>
{
    public int Id { get; set; }
}