using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;

public class GetAllHomeWorkQueryHandler(IHomeWorkReadRepository readRepository)
    : IRequestHandler<GetAllHomeWorkQueryRequest, GetAllHomeWorkQueryResponse>
{
    public async Task<GetAllHomeWorkQueryResponse> Handle(GetAllHomeWorkQueryRequest request,
        CancellationToken cancellationToken)
    {
        var homeworks = await readRepository.GetAll()
            .Include(x => x.Student) // Öğrenci ilişkisini dahil et
            .Select(x => new HomeWorkDTO()
            {
                Id = x.Id,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                Status = x.Status,
                Content = x.Content,
            }).ToListAsync(cancellationToken);

        
        return new GetAllHomeWorkQueryResponse
        {
            HomeWorkDtos = homeworks
        };
    }
}