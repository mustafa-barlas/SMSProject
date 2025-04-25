using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ExamRepository;
using SMS.DtoLayer.Exam;

namespace SMS.Application.Features.Queries.Exam.GetAllExam;

public class GetAllExamQueryHandler(IExamReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetAllExamQueryRequest, GetAllExamQueryResponse>
{
    public async Task<GetAllExamQueryResponse> Handle(GetAllExamQueryRequest request,
        CancellationToken cancellationToken)
    {
        var exams = readRepository.GetAll().ToList(); // GetAllAsync kullanarak veriyi alıyoruz.
        var examDtos = mapper.Map<List<ExamDto>>(exams); // Veriyi ExamDto'ya dönüştürüyoruz.

        return new GetAllExamQueryResponse
        {
            Exams = examDtos
        };
    }
}