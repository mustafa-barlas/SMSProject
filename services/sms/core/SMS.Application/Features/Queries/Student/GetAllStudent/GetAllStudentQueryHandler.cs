using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Queries.Student.GetAllStudent;

public class GetAllStudentQueryHandler(IStudentReadRepository readRepository) : IRequestHandler<GetAllStudentQueryRequest, GetAllStudentQueryResponse>
{
    public async Task<GetAllStudentQueryResponse> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
    {
        var student = readRepository.GetAll(false).Include(x => x.Modules).ThenInclude(x => x.Topics)
            .Select(s => new
            {
                s.Id,
                s.Name,
                s.Age,
                s.Status,
                s.CreatedDate,
                s.UpdatedDate,
                s.Modules
            }).ToList();

        return new GetAllStudentQueryResponse()
        {
            Students =  student
        };
    }
}