using SMS.DtoLayer.Exam;

namespace SMS.Application.Features.Queries.Exam.GetAllExam;

public class GetAllExamQueryResponse
{
    public List<ExamDto> Exams { get; set; } = new List<ExamDto>();
}