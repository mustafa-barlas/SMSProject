using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;

namespace SMS.Application.Features.Commands.StudentModule.UpdateStudentModule;

public class UpdateStudentModuleCommandHandler(
    IStudentModuleReadRepository readRepo,
    IStudentModuleWriteRepository writeRepo,
    IMapper mapper)
    : IRequestHandler<UpdateStudentModuleCommandRequest, UpdateStudentModuleCommandResponse>
{
    public async Task<UpdateStudentModuleCommandResponse> Handle(UpdateStudentModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var studentModule = await readRepo
            .GetWhere(sm =>
                sm.StudentId == request.StudentModuleUpdateDto.StudentId &&
                sm.ModuleId == request.StudentModuleUpdateDto.ModuleId)
            .FirstOrDefaultAsync(cancellationToken);

        if (studentModule == null)
            throw new Exception("Kayıt bulunamadı.");
        mapper.Map(request.StudentModuleUpdateDto, studentModule);
        writeRepo.Update(studentModule);
        await writeRepo.SaveAsync();
        return new UpdateStudentModuleCommandResponse();
    }
}