using System.Runtime.InteropServices.JavaScript;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentRepository;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent;

public class GetByIdStudentQueryHandler(IStudentReadRepository readRepository)
    : IRequestHandler<GetByIdStudentQueryRequest, GetByIdStudentQueryResponse>
{
    public async Task<GetByIdStudentQueryResponse> Handle(GetByIdStudentQueryRequest request,
        CancellationToken cancellationToken)
    {
        var student = await readRepository
            .GetWhere(s => s.Id == request.StudentId)
            .FirstOrDefaultAsync(cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {request.StudentId} not found");
        }

        var response = new GetByIdStudentQueryResponse
        {
            Student = new StudentDetailDTO()
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                ImageUrl = student.ImageUrl,
                Status = student.Status,
                CreatedDate = student.CreatedDate,
                UpdatedDate = student.UpdatedDate,
            }
        };

        return response;
    }
}