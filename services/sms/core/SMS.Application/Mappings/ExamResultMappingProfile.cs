using AutoMapper;
using SMS.Application.Features.Commands.ExamResult.CreateExamResult;
using SMS.Application.Features.Queries.ExamResult.GetExamResultByStudentId;
using SMS.Application.Features.Queries.ExamResult.GetExamResultsByExamId;
using SMS.Domain.Entities;
using SMS.DtoLayer.ExamResult;

namespace SMS.Application.Mappings;

public class ExamResultMappingProfile : Profile
{
    public ExamResultMappingProfile()
    {
        // Create komutu için
        CreateMap<CreateExamResultCommandRequest, ExamResult>()
            .ForMember(d => d.CreatedDate, o => o.MapFrom(_ => DateTime.UtcNow))
            .ForMember(d => d.UpdatedDate, o => o.MapFrom(_ => DateTime.UtcNow));

        // Listeleme DTO’su
        CreateMap<ExamResult, ExamResultListDto>()
            .ForMember(d => d.NetScore, o => o.MapFrom(s => s.Correct - s.Incorrect / 4.0))
            .ReverseMap();

        // Detaylı DTO (Student, Exam ve Module bilgilerini içerir)
        CreateMap<ExamResult, ExamResultDto>()
            .ForMember(d => d.ExamTitle, o => o.MapFrom(s => s.Exam.Title))
            .ForMember(d => d.ModuleTitle, o => o.MapFrom(s => s.Module.Title))
            .ForMember(d => d.NetScore, o => o.MapFrom(s => s.Correct - s.Incorrect / 4.0))
            .ForMember(d => d.StudentName, o => o.MapFrom(s => s.Student.Name + " " + s.Student.Surname))
            .ReverseMap();


        CreateMap<GetExamResultsByExamIdQueryRequest, ExamResult>().ReverseMap();
        CreateMap<GetExamResultsByExamIdQueryRequest, ExamResultListDto>().ReverseMap();
        
        CreateMap<GetExamResultsByStudentIdQueryRequest, ExamResult>().ReverseMap();
        CreateMap<GetExamResultsByStudentIdQueryRequest, ExamResultListDto>().ReverseMap();
    }
}