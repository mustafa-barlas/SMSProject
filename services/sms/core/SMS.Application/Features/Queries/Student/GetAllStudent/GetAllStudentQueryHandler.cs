using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentRepository;
using SMS.DtoLayer.HomeWork;
using SMS.DtoLayer.Module;
using SMS.DtoLayer.Student;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Student.GetAllStudent;

public class GetAllStudentQueryHandler(IStudentReadRepository readRepository)
    : IRequestHandler<GetAllStudentQueryRequest, GetAllStudentQueryResponse>
{
    public async Task<GetAllStudentQueryResponse> Handle(GetAllStudentQueryRequest request,
        CancellationToken cancellationToken)
    {
        var students = await readRepository.GetAll(false)
            .Select(s => new StudentListDto
            {
                Id = s.Id,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                Status = s.Status,
                CreatedDate = s.CreatedDate,
                UpdatedDate = s.UpdatedDate,
                DateOfBirth = s.DateOfBirth
            }).ToListAsync(cancellationToken);

        return new()
        {
            Students = students
        };
    }
}