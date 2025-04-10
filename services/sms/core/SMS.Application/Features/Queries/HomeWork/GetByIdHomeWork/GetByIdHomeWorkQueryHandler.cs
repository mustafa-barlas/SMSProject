using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto.HomeWork;
using SMS.Application.Dto.Student;
using SMS.Application.Repositories.HomeWorkRepository;

namespace SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;

public class GetByIdHomeWorkQueryHandler(IHomeWorkReadRepository readRepository)
    : IRequestHandler<GetByIdHomeWorkQueryRequest, GetByIdHomeWorkQueryResponse>
{
    public async Task<GetByIdHomeWorkQueryResponse> Handle(GetByIdHomeWorkQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetWhere(x => x.Id.Equals(request.HomeWorkId)).Include(x => x.Student)
            .FirstOrDefaultAsync(cancellationToken);

        var response = new GetByIdHomeWorkQueryResponse()
        {
            HomeWork = new GetByIdHomeWorkDto()
            {
                HomeWorkId = query.Id.ToString(),
                Title = query.Title,
                CreatedDate = query.CreatedDate,
                UpdatedDate = query.UpdatedDate,
                Status = query.Status,
                Content = query.Content,
                Student = new StudentDto
                {
                    StudentId = query.Student.Id.ToString(),
                    StudentName = query.Student.Name
                }
            }
        };

        return new GetByIdHomeWorkQueryResponse()
        {
            HomeWork = response
        };
    }
}