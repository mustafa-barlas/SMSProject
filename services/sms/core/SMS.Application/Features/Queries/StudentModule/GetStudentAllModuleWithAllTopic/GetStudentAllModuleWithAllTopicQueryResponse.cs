using SMS.DtoLayer.StudentModule;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

public class GetStudentAllModuleWithAllTopicQueryResponse
{
    public List<StudentModuleGetByIdDto> StudentModules { get; set; } = new List<StudentModuleGetByIdDto>();
}