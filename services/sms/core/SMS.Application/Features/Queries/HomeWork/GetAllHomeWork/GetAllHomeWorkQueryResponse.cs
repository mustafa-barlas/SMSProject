using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;

public class GetAllHomeWorkQueryResponse
{
    public List<GetAllHomeworkDto> HomeWorkDtos { get; set; } = new List<GetAllHomeworkDto>();
}