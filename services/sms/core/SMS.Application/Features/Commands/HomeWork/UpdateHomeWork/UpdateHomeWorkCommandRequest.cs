using MediatR;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Commands.HomeWork.UpdateHomeWork;

public class UpdateHomeWorkCommandRequest : IRequest<UpdateHomeWorkCommandResponse>
{
    public HomeWorkUpdateDto  HomeWorkUpdateDto { get; set; }
}