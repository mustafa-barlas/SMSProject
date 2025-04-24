using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.Topic.CreateTopic;
using SMS.Application.Features.Commands.Topic.RemoveTopic;
using SMS.Application.Features.Commands.Topic.UpdateTopic;
using SMS.Application.Features.Queries.Topic.GetAllTopic;
using SMS.Application.Features.Queries.Topic.GetByIdTopic;

namespace StudentManagementWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicsController(IMediator mediator) : ControllerBase
{
    // Constructor injection for IMediator

    // Get all Topics
    [HttpGet("getall")]
    public async Task<IActionResult> Get([FromQuery] int moduleId)
    {
        var request = new GetAllTopicQueryRequest { ModuleId = moduleId };
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Create a Topic
    [HttpPost("create")]
    public async Task<IActionResult> Post([FromBody] CreateTopicCommandRequest request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Get a Topic by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id) // Guid al
    {
        var request = new GetByIdTopicQueryRequest { TopicId = id }; // TopicId'yi göndermek
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Update a Topic
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateTopicCommandRequest request)
    {
        await mediator.Send(request);
        return NoContent(); // NoContent is more appropriate for successful PUT requests
    }

    // Delete a Topic
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var request = new RemoveTopicCommandRequest { Id = id };
        var response = await mediator.Send(request);
        return Ok(response);
    }
}