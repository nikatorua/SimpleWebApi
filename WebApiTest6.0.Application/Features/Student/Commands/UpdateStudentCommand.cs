using AutoMapper;
using MediatR;
using WebApiTest6._0.Application.Interfaces;

namespace WebApiTest6._0.Application.Features.Student.Commands
{
    public class UpdateStudentCommand
    {
        public class Request : IRequest
        {
            public Guid StudentId { get; private set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public void SetId(Guid StudentId)
            {
                this.StudentId = StudentId;
            }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var student = _mapper.Map<Domain.Entities.Student>(request);

                cancellationToken.ThrowIfCancellationRequested();

                await _unit.StudentRepository.UpdateAsync(request.StudentId, student);

                return Unit.Value;
            }
        }
    }
}
