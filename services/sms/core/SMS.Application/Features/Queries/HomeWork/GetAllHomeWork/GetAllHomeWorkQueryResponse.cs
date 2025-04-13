
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;

public class GetAllHomeWorkQueryResponse
{
    public List<HomeWorkDTO> HomeWorkDtos { get; set; } = new List<HomeWorkDTO>();
}