using MediatR;

namespace SMS.Application.Features.Commands.HomeWork.RemoveHomeWork;

public class RemoveHomeWorkCommandRequest: IRequest<RemoveHomeWorkCommandResponse>  
{
    public Guid? HomeWorkId { get; set; }
}