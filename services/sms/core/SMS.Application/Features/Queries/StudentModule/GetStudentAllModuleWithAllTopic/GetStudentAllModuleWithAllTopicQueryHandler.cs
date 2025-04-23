using AutoMapper;
using MediatR;
using SMS.Application.Repositories.StudentModule;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

public class GetStudentAllModuleWithAllTopicQueryHandler(IStudentModuleReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetStudentAllModuleWithAllTopicQueryRequest, GetStudentAllModuleWithAllTopicQueryResponse>
{
    public async Task<GetStudentAllModuleWithAllTopicQueryResponse> Handle(
        GetStudentAllModuleWithAllTopicQueryRequest request, CancellationToken cancellationToken)
    {
        // var studentModules = await readRepository.GetWithModulesAndTopicsByStudentIdAsync(request.StudentId);
        //
        // var response = mapper.Map<List<StudentModuleGetByIdDto>>(studentModules);
        //
        // return new()
        // {
        //     StudentModules = response
        // };

        return new();
    }
}



// public async Task<ICollection<StudentModule>> GetByStudentIdAsync(int studentId)
// {
//     return await _context.StudentModules
//         .Include(sm => sm.Module) // navigation property
//         .Where(sm => sm.StudentId == studentId)
//         .ToListAsync();
// }
//
// public async Task<List<StudentModule>> GetWithModulesAndTopicsByStudentIdAsync(int studentId)
// {
//     return await _context.StudentModules
//         .Include(sm => sm.Module)
//         .ThenInclude(m => m.Topics)
//         .Where(sm => sm.StudentId == studentId)
//         .ToListAsync();
// }