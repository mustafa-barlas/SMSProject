using MediatR;
using SMS.DtoLayer.HomeWork;

namespace SMS.Application.Features.Commands.HomeWork.CreateHomeWork;

public class CreateHomeWorkCommandRequest : IRequest<CreateHomeWorkCommandResponse>
{
    
    public string Title { get; set; }
    public string Content { get; set; }
    public int StudentId { get; set; }
    
    public DateTime? CreatedDate { get; set; }

    public DateTime DueDate { get; set; }

    public bool Status { get; set; }
    public bool IsFinished { get; set; }
    // public HomeWorkCreateDto HomeWorkCreateDto { get; set; }
}