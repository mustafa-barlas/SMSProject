using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;

public class GetAllHomeWorkQueryHandler(
    IHomeWorkReadRepository readRepository,
    IMapper mapper)
    : IRequestHandler<GetAllHomeWorkQueryRequest, GetAllHomeWorkQueryResponse>
{
    public async Task<GetAllHomeWorkQueryResponse> Handle(GetAllHomeWorkQueryRequest request,
        CancellationToken cancellationToken)
    {
        var homeworks = await readRepository.GetAll().Where(x => request.StudentId == x.StudentId)
            .Include(x => x.Student)
            .ToListAsync(cancellationToken);

        var result = mapper.Map<List<GetAllHomeworkDto>>(homeworks);

        return new GetAllHomeWorkQueryResponse
        {
            HomeWorkDtos = result
        };
    }
}