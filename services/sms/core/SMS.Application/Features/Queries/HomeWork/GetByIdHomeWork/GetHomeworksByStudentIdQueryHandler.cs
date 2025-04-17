using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.DtoLayer.HomeWork;

public class GetHomeworksByStudentIdQueryHandler(IHomeWorkReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetHomeworksByStudentIdQueryRequest, GetHomeworksByStudentIdQueryResponse>
{
    public async Task<GetHomeworksByStudentIdQueryResponse> Handle(GetHomeworksByStudentIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var homeworks = await readRepository.GetAll(false).Include(x => x.Student)
            .Where(x => x.StudentId.Equals(request.StudentId)).ToListAsync(cancellationToken);

        var result = mapper.Map<List<GetAllHomeworkDto>>(homeworks);

        return new GetHomeworksByStudentIdQueryResponse()
        {
            Homeworks = result
        };
    }
}