using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;

namespace SMS.Application.Features.Commands.StudentModule.UpdateStudentModule;

public class UpdateStudentModuleCommandHandler(
    IStudentModuleReadRepository readRepo,
    IStudentModuleWriteRepository writeRepo)
    : IRequestHandler<UpdateStudentModuleCommandRequest, UpdateStudentModuleCommandResponse>
{
    public async Task<UpdateStudentModuleCommandResponse> Handle(UpdateStudentModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var studentModule = await readRepo
            .GetWhere(sm => sm.StudentId == request.StudentId && sm.ModuleId == request.ModuleId)
            .FirstOrDefaultAsync(cancellationToken);

        if (studentModule == null)
            throw new Exception("Kayıt bulunamadı.");

        studentModule.IsActive = request.IsActive;
        writeRepo.Update(studentModule);
        await writeRepo.SaveAsync();
        return new UpdateStudentModuleCommandResponse();
    }
}