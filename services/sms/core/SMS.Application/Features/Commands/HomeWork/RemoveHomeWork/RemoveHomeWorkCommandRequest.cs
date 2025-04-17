using MediatR;

namespace SMS.Application.Features.Commands.HomeWork.RemoveHomeWork;

public class RemoveHomeWorkCommandRequest: IRequest<RemoveHomeWorkCommandResponse>  
{
    public int Id { get; set; }
}