using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;
using SMS.DtoLayer.StudentModule;

namespace SMS.Application.Features.Queries.StudentModule.GetStudentModuleById;

public class GetByIdStudentModuleQueryHandler(IStudentModuleReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetByIdStudentModuleQueryRequest, GetByIdStudentModuleQueryResponse>
{
    public async Task<GetByIdStudentModuleQueryResponse> Handle(GetByIdStudentModuleQueryRequest request,
        CancellationToken cancellationToken)
    {
        var studentModules = await readRepository
            .GetWhere(x => x.StudentId == request.StudentId)
            .Include(x => x.Module)
            .ThenInclude(m => m.Topics)
            .Include(x => x.Student)
            .ToListAsync(cancellationToken);

        var dtoList = mapper.Map<List<StudentModuleGetByIdDto>>(studentModules);

        return new GetByIdStudentModuleQueryResponse
        {
            StudentModules = dtoList
        };
    }
}