using MediatR;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Commands.HomeWork.CreateHomeWork;

public class CreateHomeWorkCommandRequest : IRequest<CreateHomeWorkCommandResponse>
{
    public HomeWorkCreateDto HomeWorkCreateDto { get; set; }
}