using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto.HomeWork;
using SMS.Application.Dto.Module;
using SMS.Application.Dto.Student;
using SMS.Application.Dto.Topic;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Queries.Student.GetAllStudent;

public class GetAllStudentQueryHandler(IStudentReadRepository readRepository)
    : IRequestHandler<GetAllStudentQueryRequest, GetAllStudentQueryResponse>
{
    public async Task<GetAllStudentQueryResponse> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
    {
        var students = await readRepository.GetAll(false)
            .Include(s => s.StudentModules)
            .ThenInclude(sm => sm.Module)
            .ThenInclude(m => m.Topics) 
            .Include(x => x.HomeWorks)// module → topics
            .Select(s => new StudentDto
            {
                StudentId  = s.Id.ToString(),
                StudentName = s.Name,
                DateOfBirth = s.DateOfBirth,
                ImageUrl = s.ImageUrl,
                Status = s.Status,
                CreatedDate = s.CreatedDate,
                UpdatedDate = s.UpdatedDate,
                HomeWorks = s.HomeWorks.Select(x => new GetByIdHomeWorkDto()
                {
                    Title = x.Title,
                    Content = x.Content,
                    Status = x.Status,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    
                }).ToList(),
                Modules = s.StudentModules.Select(sm => new ModuleDto
                {
                    ModuleId = sm.Module.Id.ToString(),
                    ModuleName = sm.Module.Name,
                    Topics = sm.Module.Topics.Select(t => new TopicDto
                    {
                        TopicId = t.Id, 
                        TopicName= t.Name
                    }).ToList()
                }).ToList()
            })
            .ToListAsync(cancellationToken);

        return new GetAllStudentQueryResponse
        {
            Students = students
        };
    }
}
