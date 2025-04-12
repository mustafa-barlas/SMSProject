using MediatR;
using SMS.Application.Dto.StudentModule;
using SMS.Application.Dto.Topic;
using SMS.Application.Repositories.StudentModule;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

public class GetStudentAllModuleWithAllTopicQueryHandler(IStudentModuleReadRepository readRepository)
    : IRequestHandler<GetStudentAllModuleWithAllTopicQueryRequest, GetStudentAllModuleWithAllTopicQueryResponse>
{
    public async Task<GetStudentAllModuleWithAllTopicQueryResponse> Handle(
        GetStudentAllModuleWithAllTopicQueryRequest request, CancellationToken cancellationToken)
    {
        var studentModules = await readRepository.GetWithModulesAndTopicsByStudentIdAsync(request.StudentId);

        var result = studentModules.Select(sm => new StudentModuleDto
        {
            StudentId = sm.StudentId,
            ModuleId = sm.Module.Id,
            ModuleName = sm.Module.Name,
            IsActive = sm.IsActive,
            Topics = sm.Module.Topics.Select(t => new TopicDto
            {
                TopicId = t.Id,
                TopicName = t.Name
            }).ToList()
        }).ToList();

        return new()
        {
            StudentModule = result
        };
    }
}