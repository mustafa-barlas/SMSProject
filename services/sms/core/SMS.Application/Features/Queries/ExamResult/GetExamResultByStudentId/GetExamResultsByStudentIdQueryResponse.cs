using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Features.Queries.ExamResult.GetExamResultByStudentId;

public class GetExamResultsByStudentIdQueryResponse
{
    public List<ExamResultDto> Results { get; set; } = new();

}