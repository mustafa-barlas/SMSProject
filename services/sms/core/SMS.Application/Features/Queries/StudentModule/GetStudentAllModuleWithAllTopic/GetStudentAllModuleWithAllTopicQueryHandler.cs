using MediatR;
using SMS.Application.Repositories.StudentModule;
using SMS.DtoLayer.StudentModule;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

public class GetStudentAllModuleWithAllTopicQueryHandler(IStudentModuleReadRepository readRepository)
    : IRequestHandler<GetStudentAllModuleWithAllTopicQueryRequest, GetStudentAllModuleWithAllTopicQueryResponse>
{
    public async Task<GetStudentAllModuleWithAllTopicQueryResponse> Handle(
        GetStudentAllModuleWithAllTopicQueryRequest request, CancellationToken cancellationToken)
    {
        var studentModules = await readRepository.GetWithModulesAndTopicsByStudentIdAsync(request.StudentId);

        var result = studentModules.Select(sm => new StudentModuleWithTopicDto()
        {
            StudentId = sm.StudentId,
            ModuleId = sm.Module.Id,
            ModuleName = sm.Module.Name,
            IsActive = sm.IsActive,
            TopicDtos = sm.Module.Topics.Select(t => new TopicDto
            {
                Id = t.Id,
                TopicName = t.Name
            }).ToList()
        }).ToList();

        return new()
        {
            StudentModule = result
        };
    }
}