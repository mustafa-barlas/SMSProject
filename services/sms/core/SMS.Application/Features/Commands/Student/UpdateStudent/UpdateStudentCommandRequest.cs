using MediatR;
using SMS.Application.Features.Commands.Student.RemoveStudent;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Commands.Student.UpdateStudent;

public class UpdateStudentCommandRequest : IRequest<UpdateStudentCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }
    public bool? Status { get; set; }

    // public StudentUpdateDto StudentUpdateDto { get; set; }
}