using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.StudentModule.CreateStudentModule;
using SMS.Application.Features.Commands.StudentModule.RemoveStudentModule;
using SMS.Application.Features.Queries.StudentModule.GetStudentModuleById;

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
        public async Task<IActionResult> GetStudentModules(int studentId)
        {
            var query = new GetByIdStudentModuleQueryRequest() { StudentId = studentId };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("remove-student-module")]
        public async Task<IActionResult> Remove([FromQuery] int studentId, [FromQuery] int moduleId)
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