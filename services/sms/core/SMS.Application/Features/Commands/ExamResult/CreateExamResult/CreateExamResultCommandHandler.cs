using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ExamResultRepository;

namespace SMS.Application.Features.Commands.ExamResult.CreateExamResult;

public class CreateExamResultCommandHandler(IExamResultWriteRepository examResultWriteRepository, IMapper mapper)
    : IRequestHandler<CreateExamResultCommandRequest, CreateExamResultCommandResponse>
{
    public async Task<CreateExamResultCommandResponse> Handle(CreateExamResultCommandRequest request,
        CancellationToken cancellationToken)
    {
        // DTO'dan Entity'ye dönüşüm
        var examResult = mapper.Map<Domain.Entities.ExamResult>(request);

        // Net puan hesaplama
        examResult.NetScore = CalculateNetScore(request.Correct, request.InCorrect);

        // Veritabanına kaydetme
        await examResultWriteRepository.AddAsync(examResult);
        await examResultWriteRepository.SaveAsync();

        return new CreateExamResultCommandResponse();
    }

    private double CalculateNetScore(int correctAnswers, int incorrectAnswers)
    {
        // Net puan hesaplama (örneğin 4 yanlış 1 doğruyu götürüyor)
        return correctAnswers - (incorrectAnswers / 4.0);
    }
}