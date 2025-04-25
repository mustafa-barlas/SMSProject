using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.Exam.CreateExam;
using SMS.Application.Features.Commands.Exam.RemoveExam;
using SMS.Application.Features.Commands.Exam.UpdateExam;
using SMS.Application.Features.Queries.Exam.GetAllExam;
using SMS.Application.Features.Queries.Exam.GetByIdExam;

namespace StudentManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController(IMediator mediator) : ControllerBase
    {
        // Get All Exams
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllExamQueryRequest());
            return Ok(response);
        }

        // Get Exam by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) // ID'yi int olarak alıyoruz
        {
            var response = await mediator.Send(new GetExamByIdQueryRequest { Id = id });
            return Ok(response);
        }

        // Create Exam
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateExamCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response); // 201 Created
        }

        // Update Exam
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateExamCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        // Delete Exam
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new RemoveExamCommandRequest { Id = id });
            return Ok(response);
        }
    }
}