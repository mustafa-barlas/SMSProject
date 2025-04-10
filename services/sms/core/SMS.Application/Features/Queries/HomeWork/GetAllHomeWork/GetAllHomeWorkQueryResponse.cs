using SMS.Application.Dto.HomeWork;

namespace SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;

public class GetAllHomeWorkQueryResponse
{
    public List<GetByIdHomeWorkDto> HomeWorkDtos { get; set; } = new List<GetByIdHomeWorkDto>();
}