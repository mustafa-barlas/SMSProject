using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.StudentModule.CreateStudentModule;
using SMS.Application.Features.Commands.StudentModule.RemoveStudentModule;
using SMS.Application.Features.Queries.StudentModule.GetStudentAllModuleWithAllTopic;

namespace StudentManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentModulesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentModuleCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("get-by-student/{studentId}")]
        public async Task<IActionResult> GetStudentModules(Guid studentId)
        {
            var query = new GetStudentAllModuleWithAllTopicQueryRequest() { StudentId = studentId };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("remove-student-module")]
        public async Task<IActionResult> Remove([FromQuery] Guid studentId, [FromQuery] Guid moduleId)
        {
            var commandRequest = new RemoveStudentModuleCommandRequest
            {
                StudentId = studentId,
                ModuleId = moduleId
            };

            var response = await mediator.Send(commandRequest);

            if (response.Success)
            {
                return Ok(new { Message = response.Message });
            }

            return BadRequest(new { Message = response.Message });
        }
    }
}