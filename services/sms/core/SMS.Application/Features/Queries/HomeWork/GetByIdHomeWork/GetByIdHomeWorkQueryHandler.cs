using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.Student;

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
            HomeWork = new GetHomeWorkWithStudentDTO()
            {
                Id = query.Id,
                Title = query.Title,
                CreatedDate = query.CreatedDate,
                UpdatedDate = query.UpdatedDate,
                Status = query.Status,
                Content = query.Content,
                StudentDetailDto = new StudentDetailDTO()
                {
                    Id = query.Student.Id,
                    Name = query.Student.Name,
                }
            }
        };

        return new GetByIdHomeWorkQueryResponse()
        {
            HomeWork = response
        };
    }
}