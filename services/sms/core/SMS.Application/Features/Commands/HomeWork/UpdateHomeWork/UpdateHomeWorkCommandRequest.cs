using MediatR;

namespace SMS.Application.Features.Commands.HomeWork.UpdateHomeWork;

public class UpdateHomeWorkCommandRequest : IRequest<UpdateHomeWorkCommandResponse>
{
    public Guid? HomeWorkId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool Status { get; set; }

    public Guid? StudentId { get; set; }
}