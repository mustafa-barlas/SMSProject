using MediatR;

namespace SMS.Application.Features.Commands.Module.ChangeStatusModule;

public class ChangeStatusModuleCommandRequest : IRequest<ChangeStatusModuleCommandResponse>
{
    public int Id { get; set; }
    public bool Status { get; set; }
}