using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Queries.Student.GetByIdStudent
{
    public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQueryRequest, GetByIdStudentQueryResponse>
    {
        private readonly IStudentReadRepository _readRepository;

        // Constructor injection for IStudentReadRepository
        public GetByIdStudentQueryHandler(IStudentReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetByIdStudentQueryResponse> Handle(GetByIdStudentQueryRequest request,
            CancellationToken cancellationToken)
        {
            var student = await _readRepository.GetWhere(s => s.Id.Equals(Guid.Parse(request.StudentId)))
                .Include(x => x.Modules)
                .FirstOrDefaultAsync(cancellationToken);

            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {request.StudentId} not found");
            }

            // Create the response
            var response = new GetByIdStudentQueryResponse
            {
                Student = new GetByIdStudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age,
                    Status = student.Status,
                    CreatedDate = student.CreatedDate,
                    UpdatedDate = student.UpdatedDate,
                    Modules = new List<ModuleDto>(),
                }
            };

            return response;
        }
    }
}