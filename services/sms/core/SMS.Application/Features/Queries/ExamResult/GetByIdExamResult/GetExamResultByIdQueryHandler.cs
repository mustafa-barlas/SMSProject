using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ExamResultRepository;
using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Features.Queries.ExamResult.GetByIdExamResult;

public class GetExamResultByIdQueryHandler(
    IExamResultReadRepository readRepository,
    IMapper mapper)
    : IRequestHandler<GetExamResultByIdQueryRequest, GetExamResultByIdQueryResponse>
{
    public async Task<GetExamResultByIdQueryResponse> Handle(GetExamResultByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var result = await readRepository.GetByIdAsync(request.Id);

        return new GetExamResultByIdQueryResponse
        {
            ExamResultListDto = mapper.Map<ExamResultListDto>(result)
        };
    }
}