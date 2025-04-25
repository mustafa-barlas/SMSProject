using AutoMapper;
using SMS.Application.Features.Commands.Exam.CreateExam;
using SMS.Application.Features.Commands.Exam.UpdateExam;
using SMS.Application.Features.Queries.Exam.GetAllExam;
using SMS.Domain.Entities;
using SMS.DtoLayer.Exam;

namespace SMS.Application.Mappings;

public class ExamMappingProfile : Profile
{
    public ExamMappingProfile()
    {
        CreateMap<Exam, ExamCreateDto>().ReverseMap();
        CreateMap<Exam, ExamUpdateDto>().ReverseMap();
        CreateMap<Exam, ExamDto>().ReverseMap();


        CreateMap<CreateExamCommandRequest, Exam>().ReverseMap();
        CreateMap<UpdateExamCommandRequest, Exam>().ReverseMap();
        CreateMap<GetAllExamQueryResponse, Exam>().ReverseMap();
    }
}