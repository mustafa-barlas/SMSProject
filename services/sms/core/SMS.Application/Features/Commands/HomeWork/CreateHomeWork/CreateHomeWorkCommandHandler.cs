using AutoMapper;
using MediatR;
using SMS.Application.Repositories.HomeWorkRepository;

namespace SMS.Application.Features.Commands.HomeWork.CreateHomeWork;

public class CreateHomeWorkCommandHandler(IHomeWorkWriteRepository writeRepository, IMapper mapper)
    : IRequestHandler<CreateHomeWorkCommandRequest, CreateHomeWorkCommandResponse>
{
    public async Task<CreateHomeWorkCommandResponse> Handle(CreateHomeWorkCommandRequest request,
        CancellationToken cancellationToken)
    {
       var homework = mapper.Map<Domain.Entities.HomeWork>(request.HomeWorkCreateDto);
       await writeRepository.AddAsync(homework);
        
        await writeRepository.SaveAsync();
        return new CreateHomeWorkCommandResponse();
    }
}