using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.StudentModule;

namespace SMS.Application.Features.Commands.StudentModule.RemoveStudentModule;

public class RemoveStudentModuleCommandHandler(
    IStudentModuleReadRepository readRepository,
    IStudentModuleWriteRepository writeRepository) :
    IRequestHandler<RemoveStudentModuleCommandRequest, RemoveStudentModuleCommandResponse>
{
    public async Task<RemoveStudentModuleCommandResponse> Handle(RemoveStudentModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var studentModule = await readRepository
            .GetWhere(sm => sm.StudentId == request.StudentId && sm.ModuleId == request.ModuleId)
            .FirstOrDefaultAsync(cancellationToken);

        // Silme işlemini yap
        if (studentModule != null) writeRepository.Remove(studentModule);
         await writeRepository.SaveAsync();


         return new RemoveStudentModuleCommandResponse();
    }
}