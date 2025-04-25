using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Features.Queries.ExamResult.GetExamResultsByExamId;

public class GetExamResultsByExamIdQueryResponse
{
    public List<ExamResultDto> Results { get; set; } = new();
}