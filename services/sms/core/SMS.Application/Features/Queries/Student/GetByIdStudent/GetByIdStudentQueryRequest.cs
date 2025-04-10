using MediatR;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent;

public class GetByIdStudentQueryRequest : IRequest<GetByIdStudentQueryResponse>
{
    public string StudentId { get; set; }
}