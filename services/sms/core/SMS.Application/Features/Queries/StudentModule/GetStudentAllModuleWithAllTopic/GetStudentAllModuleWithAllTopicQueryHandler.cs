using AutoMapper;
using MediatR;
using SMS.Application.Repositories.StudentModule;
using SMS.DtoLayer.Student;
using SMS.DtoLayer.StudentModule;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

public class GetStudentAllModuleWithAllTopicQueryHandler(IStudentModuleReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetStudentAllModuleWithAllTopicQueryRequest, GetStudentAllModuleWithAllTopicQueryResponse>
{
    public async Task<GetStudentAllModuleWithAllTopicQueryResponse> Handle(
        GetStudentAllModuleWithAllTopicQueryRequest request, CancellationToken cancellationToken)
    {
        var studentModules = await readRepository.GetWithModulesAndTopicsByStudentIdAsync(request.StudentId);

        var response = mapper.Map<List<StudentModuleGetByIdDto>>(studentModules);

        return new()
        {
            StudentModules = response
        };
    }
}