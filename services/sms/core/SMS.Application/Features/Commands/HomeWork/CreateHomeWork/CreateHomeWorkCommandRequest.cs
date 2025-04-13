using MediatR;

namespace SMS.Application.Features.Commands.HomeWork.CreateHomeWork;

public class CreateHomeWorkCommandRequest : IRequest<CreateHomeWorkCommandResponse>
{
    public string? Title { get; set; } = string.Empty;
    public string? Content { get; set; } = string.Empty;
    public bool Status { get; set; }
    public Guid StudentId { get; set; }
}