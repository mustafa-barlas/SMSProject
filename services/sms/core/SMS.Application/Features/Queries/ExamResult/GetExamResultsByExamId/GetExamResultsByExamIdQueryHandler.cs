using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.ExamResultRepository;
using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Features.Queries.ExamResult.GetExamResultsByExamId;

public class GetExamResultsByExamIdQueryHandler(
    IExamResultReadRepository readRepository,
    IMapper mapper
) : IRequestHandler<GetExamResultsByExamIdQueryRequest, GetExamResultsByExamIdQueryResponse>
{
    public async Task<GetExamResultsByExamIdQueryResponse> Handle(
        GetExamResultsByExamIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        // ExamId ve StudentId'ye göre filtreleme yapıyoruz
        var entities = await readRepository.GetWhere(
                er => er.Exam.Id == request.ExamId && er.Student.Id == request.StudentId,
                false)
            .Include(er => er.Exam) // Sınav bilgisini dahil et
            .Include(er => er.Module) // Modül bilgisini dahil et
            .Include(er => er.Student) // Öğrenci bilgisini dahil et
            .ToListAsync(cancellationToken); // Sonuçları listele

        // Mapping işlemi: Entity'leri DTO'ya çevir
        var dtos = mapper.Map<List<ExamResultDto>>(entities);

        // DTO'ları dönüyoruz
        return new GetExamResultsByExamIdQueryResponse
        {
            Results = dtos
        };
    }
}