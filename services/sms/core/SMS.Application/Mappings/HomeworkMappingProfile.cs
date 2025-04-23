using AutoMapper;
using SMS.Application.Features.Commands.HomeWork.CreateHomeWork;
using SMS.Domain.Entities;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Mappings;

public class HomeworkMappingProfile : Profile
{
    public HomeworkMappingProfile()
    {
        CreateMap<HomeWork, HomeWorkCreateDto>().ReverseMap();
        CreateMap<HomeWork, HomeWorkUpdateDto>().ReverseMap();
        CreateMap<HomeWork, GetHomeworkDto>().ReverseMap();
        CreateMap<HomeWork, GetAllHomeworkDto>().ReverseMap();
        
        CreateMap<CreateHomeWorkCommandRequest, HomeWork>().ReverseMap();
        CreateMap<HomeWorkCreateDto, CreateHomeWorkCommandRequest>().ReverseMap();

    }
}