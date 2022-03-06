using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiTest6._0.Application.Features.Student.Commands;
using WebApiTest6._0.Application.Features.Student.Queries;
using WebApiTest6._0.Domain.Entities;

namespace WebApiTest6._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<Student> Get([FromRoute] Guid id) => await _mediator.Send(new GetStudentByIDQuery.Request(id));

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateStudentCommand.Request request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtRoute("GetStudentById", new { Id = result }, result);
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAll() => await _mediator.Send(new GetStudentAllQuery.Request());

        [HttpPut("{id}", Name = "UpdateStudent")]
        public async Task UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentCommand.Request request)
        {
            request.SetId(id);
            await _mediator.Send(request);
        }
    }
}
