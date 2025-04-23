using MediatR;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentModuleById;

public class GetByIdStudentModuleQueryRequest : IRequest<GetByIdStudentModuleQueryResponse>
{
    public int StudentId { get; set; }

}