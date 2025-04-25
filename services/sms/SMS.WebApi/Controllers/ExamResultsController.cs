using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Commands.ExamResult.CreateExamResult;
using SMS.Application.Features.Commands.ExamResult.RemoveExamResult;
using SMS.Application.Features.Queries.ExamResult.GetAllExamResult;
using SMS.Application.Features.Queries.ExamResult.GetByIdExamResult;
using SMS.Application.Features.Queries.ExamResult.GetExamResultByStudentId;
using SMS.Application.Features.Queries.ExamResult.GetExamResultsByExamId;

namespace StudentManagementWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamResultsController(IMediator mediator) : ControllerBase
{
    // GET api/examresults
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new GetAllExamResultQueryRequest());
        return Ok(response); // response.Results => List<ExamResultListDto>
    }

    // GET api/examresults/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await mediator.Send(new GetExamResultByIdQueryRequest { Id = id });

        return Ok(response); // response.ExamResult => ExamResultListDto
    }

    // GET api/examresults/student/{studentId}
    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetByStudent(int studentId)
    {
        var response = await mediator.Send(
            new GetExamResultsByStudentIdQueryRequest { StudentId = studentId });
        return Ok(response);
    }

    // GET api/examresults/exam/{examId}
    [HttpGet("exam/{examId}")]
    public async Task<IActionResult> GetByExam(int examId, int studentId)
    {
        var response = await mediator.Send(new GetExamResultsByExamIdQueryRequest()
            { ExamId = examId, StudentId = studentId });
        return Ok(response);
    }

    // POST api/examresults
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateExamResultCommandRequest request)
    {
        var response = await mediator.Send(request);
        return StatusCode(201, response); // Created status
    }

    // DELETE api/examresults/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await mediator.Send(new RemoveExamResultCommandRequest { Id = id });
        return Ok(response);
    }
}