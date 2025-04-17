using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;

public class GetHomeworksByStudentIdQueryResponse
{
    public List<GetAllHomeworkDto> Homeworks { get; set; } = new();
}