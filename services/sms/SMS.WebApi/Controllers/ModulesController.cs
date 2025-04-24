using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.Module.ChangeStatusModule;
using SMS.Application.Features.Commands.Module.CreateModule;
using SMS.Application.Features.Commands.Module.RemoveModule;
using SMS.Application.Features.Commands.Module.UpdateModule;
using SMS.Application.Features.Queries.Module.GetAllModule;
using SMS.Application.Features.Queries.Module.GetByIdModule;

namespace StudentManagementWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModulesController(IMediator mediator) : ControllerBase
{

    // Get all Modules
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllModuleQueryRequest request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Create a Module
    [HttpPost("create")]
    public async Task<IActionResult> Post([FromBody] CreateModuleCommandRequest request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Get a Module by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id) 
    {
        var request = new GetByIdModuleQueryRequest { Id = id }; // ModuleId'yi göndermek
        var response = await mediator.Send(request);
        return Ok(response);
    }

    // Update a Module
    [HttpPut("update")]
    public async Task<IActionResult> Put([FromBody] UpdateModuleCommandRequest request)
    {
        await mediator.Send(request);
        return NoContent(); // NoContent is more appropriate for successful PUT requests
    }

    // Delete a Module
    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var request = new RemoveModuleCommandRequest { Id = id }; 
        var response = await mediator.Send(request);
        return Ok(response);
    }
    
    public class ChangeModuleStatusRequest
    {
        public bool Status { get; set; }
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeModuleStatusRequest request)
    {
        var command = new ChangeStatusModuleCommandRequest
        {
            Id = id,
            Status = request.Status
        };

        await mediator.Send(command);
        return NoContent();
    }
}