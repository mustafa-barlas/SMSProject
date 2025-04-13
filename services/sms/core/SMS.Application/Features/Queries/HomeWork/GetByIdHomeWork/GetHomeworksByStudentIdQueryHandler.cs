using MediatR;
using SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.DtoLayer.HomeWork;

public class GetHomeworksByStudentIdQueryHandler(IHomeWorkReadRepository readRepository)
    : IRequestHandler<GetHomeworksByStudentIdQueryRequest, GetHomeworksByStudentIdQueryResponse>
{
    public async Task<GetHomeworksByStudentIdQueryResponse> Handle(GetHomeworksByStudentIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var homeworks = readRepository
            .GetWhere(hw => hw.StudentId == request.StudentId).ToList();

        var list = homeworks.Select(hw => new HomeworkListDto
        {
            Id = hw.Id,
            Title = hw.Title,
            Content = hw.Content,
            Status = hw.Status,
            StudentId = hw.StudentId
        }).ToList();

        return new GetHomeworksByStudentIdQueryResponse
        {
            Homeworks = list
        };
    }
}