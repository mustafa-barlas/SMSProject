using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentRepository;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Queries.Student.GetAllStudent;

public class GetAllStudentQueryHandler(IStudentReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetAllStudentQueryRequest, GetAllStudentQueryResponse>
{
    public async Task<GetAllStudentQueryResponse> Handle(GetAllStudentQueryRequest request,
        CancellationToken cancellationToken)
    {
        var students = await readRepository.GetAll(false)
            .ToListAsync(cancellationToken);

        var response = mapper.Map<List<GetAllStudentDto>>(students);
        
        return new()
        {
            Students = response
        };
    }
}