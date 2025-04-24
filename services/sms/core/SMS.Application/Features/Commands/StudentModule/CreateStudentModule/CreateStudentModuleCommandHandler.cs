using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.ModuleRepository;
using SMS.Application.Repositories.StudentModule;
using SMS.Application.Repositories.StudentRepository;

namespace SMS.Application.Features.Commands.StudentModule.CreateStudentModule;

public class CreateStudentModuleCommandHandler(
    IStudentReadRepository studentReadRepository,
    IModuleReadRepository moduleReadRepository,
    IStudentModuleWriteRepository studentModuleWriteRepository,
    IStudentModuleReadRepository studentModuleReadRepository,
    IMapper mapper)
    : IRequestHandler<CreateStudentModuleCommandRequest, CreateStudentModuleCommandResponse>
{
    public async Task<CreateStudentModuleCommandResponse> Handle(CreateStudentModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        // Öğrenci var mı kontrolü
        var student = await studentReadRepository.GetByIdAsync(request.StudentId);
        if (student == null)
            throw new Exception("Student not found");


        // Daha önce atanmış mı?
        var existing = await studentModuleReadRepository.GetWhere(sm =>
                sm.StudentId == request.StudentId &&
                sm.ModuleId == request.ModuleId)
            .FirstOrDefaultAsync(cancellationToken);

        if (existing != null)
            return new(); // zaten atanmış, işlem yapma

        // Yeni modül ata
        var result = mapper.Map<Domain.Entities.StudentModule>(request);

        await studentModuleWriteRepository.AddAsync(result);
        await studentModuleWriteRepository.SaveAsync();
        return new();

        #region different way

        //  1. Mevcut modülleri sil
        // var currentModules = await studentModuleReadRepository.GetByStudentIdAsync(request.StudentId);

        // foreach (var item in currentModules)
        // {
        //     studentModuleWriteRepository.Remove(item); 
        // }
        //
        // // 🟢 2. Yeni modülleri ata
        // foreach (var moduleId in request.ModuleIds.Distinct())
        // {
        //     var newStudentModule = new Domain.Entities.StudentModule
        //     {
        //         StudentId = request.StudentId,
        //         ModuleId = moduleId
        //     };
        //
        //     await studentModuleWriteRepository.AddAsync(newStudentModule);
        //     await studentModuleWriteRepository.SaveAsync();
        // }

        #endregion
    }
}