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
        // Homework verilerini al, Student ilişkisini de dahil et
        var homeworks = await readRepository.GetAll()
            .Include(x => x.Student) // ilişkili veriyi de dahil et
            .ToListAsync(cancellationToken); // Asenkron hale getir

        // AutoMapper ile veriyi DTO'ya dönüştür
        var result = mapper.Map<List<GetAllHomeworkDto>>(homeworks);

        // Dönüştürülmüş veriyi response nesnesine at
        return new GetAllHomeWorkQueryResponse
        {
            HomeWorkDtos = result // response modelini doldur
        };
    }
}