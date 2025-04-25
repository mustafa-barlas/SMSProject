using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ExamResultRepository;
using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Features.Queries.ExamResult.GetAllExamResult;

public class GetAllExamResultQueryHandler(
    IExamResultReadRepository readRepository,
    IMapper mapper) : IRequestHandler<GetAllExamResultQueryRequest, GetAllExamResultQueryResponse>
{
    public async Task<GetAllExamResultQueryResponse> Handle(GetAllExamResultQueryRequest request,
        CancellationToken cancellationToken)
    {
        var results = readRepository.GetAll().ToList();
        var response = mapper.Map<List<ExamResultListDto>>(results);
        return new()
        {
            Results = response
        };
    }
}