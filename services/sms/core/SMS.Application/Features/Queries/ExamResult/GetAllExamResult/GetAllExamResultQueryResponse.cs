using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Features.Queries.ExamResult.GetAllExamResult;

public class GetAllExamResultQueryResponse
{
    public List<ExamResultListDto> Results { get; set; } = new List<ExamResultListDto>();
}