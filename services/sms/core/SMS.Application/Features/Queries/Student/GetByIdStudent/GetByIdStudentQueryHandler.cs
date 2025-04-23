using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentRepository;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent;

public class GetByIdStudentQueryHandler(IStudentReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetByIdStudentQueryRequest, GetByIdStudentQueryResponse>
{
    public async Task<GetByIdStudentQueryResponse> Handle(GetByIdStudentQueryRequest request,
        CancellationToken cancellationToken)
    {
        var result = await readRepository.GetAll()
            .Include(x => x.HomeWorks) // HomeWorks yüklensin
            .Include(x => x.StudentModules) // StudentModules yüklensin
            .ThenInclude(sm => sm.Module) // Module'ler yüklensin
            .ThenInclude(m => m.Topics) // Topic'ler yüklensin
            .Where(x => x.Id == request.Id) // Öğrencinin Id'sine göre filtrele
            .FirstOrDefaultAsync(cancellationToken); // İlk sonucu al

// Mapping işlemi
        var response = mapper.Map<StudentGetByIdDto>(result);

        return new GetByIdStudentQueryResponse
        {
            Student = response
        };
    }
}