using MediatR;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent;

public class GetByIdStudentQueryRequest : IRequest<GetByIdStudentQueryResponse>
{
    public Guid? StudentId { get; set; }
}