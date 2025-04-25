using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ExamRepository;
using SMS.DtoLayer.Exam;

namespace SMS.Application.Features.Queries.Exam.GetByIdExam;

public class GetExamByIdQueryHandler(IExamReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetExamByIdQueryRequest, GetExamByIdQueryResponse>
{
    public async Task<GetExamByIdQueryResponse> Handle(GetExamByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var exam = await readRepository.GetByIdAsync(request.Id); // ID'ye göre sınavı alıyoruz
        if (exam == null) 
            throw new Exception("Exam not found"); // Eğer sınav bulunamazsa hata fırlatıyoruz

        var examDto = mapper.Map<ExamDto>(exam); // Sınavı ExamDto'ya dönüştürüyoruz

        return new GetExamByIdQueryResponse
        {
            Exam = examDto // Dönüştürülmüş sınavı response'a koyuyoruz
        };
    }
}