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

        if (studentModule == null)
            return new RemoveStudentModuleCommandResponse()
            {
                Success = false,
                Message = "StudentModule not found"
            };

        // Silme işlemini yap
        writeRepository.Remove(studentModule);
        var saveResult = await writeRepository.SaveAsync(); // Asenkron Save işlemi

        if (saveResult > 0) // Eğer değişiklik yapılmışsa
        {
            return new RemoveStudentModuleCommandResponse()
            {
                Success = true,
                Message = "StudentModule successfully removed"
            };
        }

        return new RemoveStudentModuleCommandResponse()
        {
            Success = false,
            Message = "Failed to remove StudentModule"
        };
    }
}