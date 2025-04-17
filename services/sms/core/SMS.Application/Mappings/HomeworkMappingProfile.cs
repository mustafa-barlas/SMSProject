using AutoMapper;
using SMS.Domain.Entities;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Mappings;

public class HomeworkMappingProfile : Profile
{
    public HomeworkMappingProfile()
    {
        CreateMap<HomeWork, HomeWorkCreateDto>().ReverseMap();
        CreateMap<HomeWork, HomeWorkUpdateDto>().ReverseMap();
        CreateMap<HomeWork, GetHomeworkByIdForUpdateDto>().ReverseMap();
        CreateMap<HomeWork, GetAllHomeworkDto>().ReverseMap();
    }
}