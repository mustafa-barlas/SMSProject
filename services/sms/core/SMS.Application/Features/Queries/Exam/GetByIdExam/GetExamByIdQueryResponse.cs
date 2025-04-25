using SMS.DtoLayer.Exam;

namespace SMS.Application.Features.Queries.Exam.GetByIdExam;

public class GetExamByIdQueryResponse
{
    public ExamDto Exam { get; set; } // Tek bir sınavı döndüreceğiz
}