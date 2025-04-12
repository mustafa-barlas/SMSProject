using MediatR;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

public class GetStudentAllModuleWithAllTopicQueryRequest : IRequest<GetStudentAllModuleWithAllTopicQueryResponse>
{
    public Guid StudentId { get; set; }
}