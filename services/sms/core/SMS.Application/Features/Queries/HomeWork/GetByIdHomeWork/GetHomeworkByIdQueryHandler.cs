using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;

public class GetHomeworkByIdQueryHandler(IHomeWorkReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetHomeworkByIdQueryRequest, GetHomeworkByIdQueryResponse>
{
    public async Task<GetHomeworkByIdQueryResponse> Handle(GetHomeworkByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var homework = await readRepository.GetWhere(x => x.Id.Equals(request.Id)).Include(x => x.Student).FirstOrDefaultAsync(cancellationToken);

        var result = mapper.Map<GetHomeworkDto>(homework);

        return new GetHomeworkByIdQueryResponse()
        {
            HomeworkDto = result
        };
    }
}