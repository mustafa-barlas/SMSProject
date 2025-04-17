using AutoMapper;
using MediatR;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Commands.HomeWork.UpdateHomeWork;

public class UpdateHomeWorkCommandHandler(
    IHomeWorkWriteRepository writeRepository,
    IHomeWorkReadRepository readRepository,
    IMapper mapper)
    : IRequestHandler<UpdateHomeWorkCommandRequest, UpdateHomeWorkCommandResponse>
{
    public async Task<UpdateHomeWorkCommandResponse> Handle(UpdateHomeWorkCommandRequest request,
        CancellationToken cancellationToken)
    {
        // ID ile mevcut HomeWork'ü bul
        var homework = await readRepository.GetByIdAsync(request.HomeWorkUpdateDto.Id);

        // DTO'daki yeni değerleri var olan entity'ye uygula
        mapper.Map(request.HomeWorkUpdateDto, homework);

        writeRepository.Update(homework);
        await writeRepository.SaveAsync();

        return new();
    }
}