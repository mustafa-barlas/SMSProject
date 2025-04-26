namespace SMS.WebUI.Services.Pdf;

public interface IExamResultPdfService
{
    Task<byte[]> GenerateExamResultsPdfAsync(int? examId, int? studentId);
}