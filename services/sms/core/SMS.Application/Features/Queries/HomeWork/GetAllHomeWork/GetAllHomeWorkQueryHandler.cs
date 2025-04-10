using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto.HomeWork;
using SMS.Application.Dto.Student;
using SMS.Application.Repositories.HomeWorkRepository;

namespace SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;

public class GetAllHomeWorkQueryHandler(IHomeWorkReadRepository readRepository)
    : IRequestHandler<GetAllHomeWorkQueryRequest, GetAllHomeWorkQueryResponse>
{
    public async Task<GetAllHomeWorkQueryResponse> Handle(GetAllHomeWorkQueryRequest request,
        CancellationToken cancellationToken)
    {
        var homeworks = await readRepository.GetAll()
            .Include(x => x.Student) // Öğrenci ilişkisini dahil et
            .Select(x => new GetByIdHomeWorkDto()
            {
                HomeWorkId = x.Id.ToString(),
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                Status = x.Status,
                Content = x.Content,
                Student = new StudentDto
                {
                    StudentId = x.Student.Id.ToString(),
                    StudentName = x.Student.Name
                }
            }).ToListAsync(cancellationToken);

        // HomeWorkDto listesini içeren response'u döndür
        return new GetAllHomeWorkQueryResponse
        {
            HomeWorkDtos = homeworks
        };
    }
}