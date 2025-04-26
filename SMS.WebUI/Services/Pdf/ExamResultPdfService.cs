using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SMS.WebUI.Services.ExamResult;
using System.Globalization;

namespace SMS.WebUI.Services.Pdf;

public class ExamResultPdfService(IExamResultService examResultService) : IExamResultPdfService
{
    public async Task<byte[]> GenerateExamResultsPdfAsync(int? examId, int? studentId)
    {
        var result = await examResultService.GetExamResultsAsync(examId, studentId);
        var culture = new CultureInfo("tr-TR");

        var totalNet = result.Sum(x => x.NetScore);
        var examDate = result.FirstOrDefault()?.ExamDate ?? DateTime.Now;

        var studentName = result.FirstOrDefault()?.StudentName ?? "Öğrenci Bilgisi Yok";
        var examTitle = result.FirstOrDefault()?.ExamTitle ?? "Sınav Bilgisi Yok";

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(50);

                // Header Section
                page.Header().Element(header =>
                {
                    header.Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            column.Item().Text($"{examTitle.ToUpper()} SINAV SONUCU")
                                .FontSize(20).Bold().FontColor(Colors.Blue.Darken3);

                            column.Item().PaddingTop(10).Text(text =>
                            {
                                text.Span("Öğrenci: ").Italic();
                                text.Span(studentName);
                            });
                        });

                        row.ConstantItem(150).Column(column =>
                        {
                            column.Item().Text(text =>
                            {
                                text.Span("Sınav Tarihi: ").SemiBold();
                                text.Span($"{examDate:dd/MM/yyyy}");
                            });

                            column.Item().PaddingTop(5).Text(text =>
                            {
                                text.Span("Sınav Kodu: ").SemiBold();
                                text.Span(examId?.ToString() ?? "-");
                            });
                        });
                    });
                });

                // Content Section
                page.Content().Element(content =>
                {
                    content.PaddingVertical(15).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3); // Konu
                            columns.RelativeColumn(); // Doğru
                            columns.RelativeColumn(); // Yanlış
                            columns.RelativeColumn(); // Net
                        });

                        // Table Header
                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderCellStyle).Text("DERS");
                            header.Cell().Element(HeaderCellStyle).AlignCenter().Text("DOĞRU");
                            header.Cell().Element(HeaderCellStyle).AlignCenter().Text("YANLIŞ");
                            header.Cell().Element(HeaderCellStyle).AlignCenter().Text("NET");

                            static IContainer HeaderCellStyle(IContainer container) => container
                                .PaddingVertical(10)
                                .Background(Colors.Grey.Lighten3)
                                .BorderBottom(2)
                                .BorderColor(Colors.Blue.Darken3)
                                .DefaultTextStyle(x => x.SemiBold());
                        });

                        // Table Rows
                        foreach (var item in result)
                        {
                            table.Cell().Element(CellStyle).Text(item.ModuleTitle.ToUpper());
                            table.Cell().Element(CellStyle).AlignCenter().Text(item.Correct.ToString());
                            table.Cell().Element(CellStyle).AlignCenter().Text(item.InCorrect.ToString());
                            table.Cell().Element(CellStyle).AlignCenter().Text(item.NetScore.ToString("0.00", culture));
                        }

                        // Total Row
                        table.Cell().ColumnSpan(3).Element(TotalCellStyle).Text("TOPLAM NET");
                        table.Cell().Element(TotalCellStyle).AlignCenter().Text(totalNet.ToString("0.00", culture));

                        static IContainer CellStyle(IContainer container) => container
                            .BorderBottom(1)
                            .BorderColor(Colors.Grey.Lighten2)
                            .PaddingVertical(8);

                        static IContainer TotalCellStyle(IContainer container) => container
                            .BorderBottom(1)
                            .BorderColor(Colors.Blue.Darken3)
                            .PaddingVertical(10)
                            .Background(Colors.Grey.Lighten4);
                    });
                });

                // Footer Section
                page.Footer().Element(footer =>
                {
                    footer.AlignCenter().Row(row =>
                    {
                        row.RelativeItem().Text(text =>
                        {
                            text.Span("Oluşturulma Tarihi: ").FontColor(Colors.Grey.Darken1);
                            text.Span($"{DateTime.Now:dd.MM.yyyy HH:mm}").SemiBold();
                        });

                        row.RelativeItem().AlignRight().Text(text =>
                        {
                            text.CurrentPageNumber().FontColor(Colors.Blue.Darken3);
                            text.Span(" / ").FontColor(Colors.Grey.Darken1);
                            text.TotalPages().FontColor(Colors.Blue.Darken3);
                        });
                    });
                });
            });
        });

        return document.GeneratePdf();
    }
}