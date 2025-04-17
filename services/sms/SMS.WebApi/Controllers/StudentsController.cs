using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.Student.CreateStudent;
using SMS.Application.Features.Commands.Student.RemoveStudent;
using SMS.Application.Features.Commands.Student.UpdateStudent;
using SMS.Application.Features.Queries.Student.GetAllStudent;
using SMS.Application.Features.Queries.Student.GetByIdStudent;
using SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

namespace StudentManagementWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    // Constructor injection for IMediator

    // Get all students
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllStudentQueryRequest request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Create a student
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateStudentCommandRequest request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Get student with all related fields (modules, topics, etc.)
    [HttpGet("{id}/all")]
    public async Task<IActionResult> GetStudentWithAllFields([FromRoute] int id)
    {
        var request = new GetStudentAllModuleWithAllTopicQueryRequest { StudentId = id };
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Get a student by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id) // int al
    {
        var request = new GetByIdStudentQueryRequest { Id = id }; // StudentId'yi göndermek
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Update a student
    [HttpPut]
    public async Task<IActionResult> Update( [FromBody] UpdateStudentCommandRequest request)
    {
        var response = await mediator.Send(request);
        return Ok(response); // veya NoContent(); (tercih meselesi)
    }

    // Delete a student
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id) // int al
    {
        var request = new RemoveStudentCommandRequest { Id = id }; // StudentId'yi göndermek
        var response = await mediator.Send(request);
        return Ok(response);
    }
}