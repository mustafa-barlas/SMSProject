using SMS.DtoLayer.StudentModule;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentModuleById;

public class GetByIdStudentModuleQueryResponse
{
    public List<StudentModuleGetByIdDto> StudentModules { get; set; } = new List<StudentModuleGetByIdDto>();

}