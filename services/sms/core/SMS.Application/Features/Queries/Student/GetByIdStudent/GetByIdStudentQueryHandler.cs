using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentRepository;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent;

public class GetByIdStudentQueryHandler(IStudentReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetByIdStudentQueryRequest, GetByIdStudentQueryResponse>
{
    public async Task<GetByIdStudentQueryResponse> Handle(GetByIdStudentQueryRequest request,
        CancellationToken cancellationToken)
    {
        var result = await readRepository.GetAll().Include(x => x.HomeWorks)
            .Include(x => x.StudentModules)
            .ThenInclude(x => x.Module).Where(x => x.Id.Equals(request.Id)).FirstOrDefaultAsync(cancellationToken);


        var response = mapper.Map<StudentGetByIdDto>(result);

        return new GetByIdStudentQueryResponse
        {
            Student = response
        };
    }
}