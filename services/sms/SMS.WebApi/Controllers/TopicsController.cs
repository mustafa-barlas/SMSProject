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
public class TopicsController : ControllerBase
{
    private readonly IMediator _mediator;

    // Constructor injection for IMediator
    public TopicsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Get all Topics
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllTopicQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // Create a Topic
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTopicCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // Get a Topic by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id) // Guid al
    {
        var request = new GetByIdTopicQueryRequest { TopicId = id.ToString() }; // TopicId'yi göndermek
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // Update a Topic
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateTopicCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent(); // NoContent is more appropriate for successful PUT requests
    }

    // Delete a Topic
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var request = new RemoveTopicCommandRequest { TopicId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}