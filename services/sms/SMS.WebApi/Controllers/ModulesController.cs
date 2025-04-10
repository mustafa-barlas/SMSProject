using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.Module.CreateModule;
using SMS.Application.Features.Commands.Module.RemoveModule;
using SMS.Application.Features.Commands.Module.UpdateModule;
using SMS.Application.Features.Queries.Module.GetAllModule;
using SMS.Application.Features.Queries.Module.GetByIdModule;

namespace StudentManagementWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModulesController : ControllerBase
{
    private readonly IMediator _mediator;

    // Constructor injection for IMediator
    public ModulesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Get all Modules
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllModuleQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // Create a Module
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateModuleCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // Get a Module by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id) // Guid al
    {
        var request = new GetByIdModuleQueryRequest { ModuleId = id }; // ModuleId'yi göndermek
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // Update a Module
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateModuleCommandRequest request)
    {
        await _mediator.Send(request);
        return NoContent(); // NoContent is more appropriate for successful PUT requests
    }

    // Delete a Module
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id) // Guid al
    {
        var request = new RemoveModuleCommandRequest { ModuleId = id.ToString() }; // ModuleId'yi göndermek
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}