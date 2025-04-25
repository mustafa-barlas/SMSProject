using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.ExamResultRepository;
using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Features.Queries.ExamResult.GetExamResultByStudentId;

public class GetExamResultsByStudentIdQueryHandler(
    IExamResultReadRepository readRepo,
    IMapper mapper) : IRequestHandler<GetExamResultsByStudentIdQueryRequest, GetExamResultsByStudentIdQueryResponse>
{
    public async Task<GetExamResultsByStudentIdQueryResponse> Handle(
        GetExamResultsByStudentIdQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var entities = await readRepo.GetWhere(er => er.StudentId == request.StudentId)
            .Include(er => er.Exam)
            .Include(er => er.Module)
            .Include(er => er.Student)
            .ToListAsync(cancellationToken);

        var dtos = mapper.Map<List<ExamResultDto>>(entities);

        return new GetExamResultsByStudentIdQueryResponse
        {
            Results = dtos
        };
    }
}