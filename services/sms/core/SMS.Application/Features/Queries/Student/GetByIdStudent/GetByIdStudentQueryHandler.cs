using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto;
using SMS.Application.Dto.Module;
using SMS.Application.Dto.Student;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent;

public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQueryRequest, GetByIdStudentQueryResponse>
{
    private readonly IStudentReadRepository _readRepository;

    public GetByIdStudentQueryHandler(IStudentReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<GetByIdStudentQueryResponse> Handle(GetByIdStudentQueryRequest request,
        CancellationToken cancellationToken)
    {
        var student = await _readRepository
            .GetWhere(s => s.Id.ToString() == request.StudentId)
            .Include(s => s.StudentModules)
            .ThenInclude(sm => sm.Module)
            .FirstOrDefaultAsync(cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {request.StudentId} not found");
        }

        var response = new GetByIdStudentQueryResponse
        {
            Student = new StudentDto()
            {
                StudentId = student.Id.ToString(),
                StudentName = student.Name,
                Age = student.Age,
                Status = student.Status,
                CreatedDate = student.CreatedDate,
                UpdatedDate = student.UpdatedDate,
                Modules = student.StudentModules.Select(sm => new ModuleDto
                {
                    ModuleId = sm.Module.Id.ToString(),
                    ModuleName = sm.Module.Name
                }).ToList()
            }
        };

        return response;
    }
}