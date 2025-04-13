using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.Student.CreateStudent;
using SMS.Application.Features.Commands.Student.RemoveStudent;
using SMS.Application.Features.Commands.Student.UpdateStudent;
using SMS.Application.Features.Queries.Student.GetAllStudent;
using SMS.Application.Features.Queries.Student.GetByIdStudent;

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

    // Get a student by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id) // Guid al
    {
        var request = new GetByIdStudentQueryRequest { StudentId = id }; // StudentId'yi göndermek
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Update a student
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateStudentCommandRequest request)
    {
        await mediator.Send(request);
        return NoContent(); // NoContent is more appropriate for successful PUT requests
    }

    // Delete a student
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id) // Guid al
    {
        var request = new RemoveStudentCommandRequest { StudentId = id.ToString() }; // StudentId'yi göndermek
        var response = await mediator.Send(request);
        return Ok(response);
    }
}