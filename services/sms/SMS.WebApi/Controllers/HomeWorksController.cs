using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.HomeWork.CreateHomeWork;
using SMS.Application.Features.Commands.HomeWork.RemoveHomeWork;
using SMS.Application.Features.Commands.HomeWork.UpdateHomeWork;
using SMS.Application.Features.Queries.HomeWork.GetAllHomeWork;
using SMS.Application.Features.Queries.HomeWork.GetByIdHomeWork;

namespace StudentManagementWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeWorksController(IMediator mediator) : ControllerBase
{
    // Get all HomeWorks
    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetHomeWorksByStudentId([FromRoute] int studentId)
    {
        var request = new GetAllHomeWorkQueryRequest() { StudentId = studentId };
        var response = await mediator.Send(request);
        return Ok(response);
    }


    // Get a HomeWork by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var request = new GetHomeworkByIdQueryRequest() { Id = id };
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Create a HomeWork
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateHomeWorkCommandRequest request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Update a HomeWork
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateHomeWorkCommandRequest request)
    {
        await mediator.Send(request);
        return NoContent(); // NoContent is more appropriate for successful PUT requests
    }

    // Delete a HomeWork
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id) // int al
    {
        var request = new RemoveHomeWorkCommandRequest { Id = id }; // HomeWorkId'yi göndermek
        var response = await mediator.Send(request);
        return Ok(response);
    }
}