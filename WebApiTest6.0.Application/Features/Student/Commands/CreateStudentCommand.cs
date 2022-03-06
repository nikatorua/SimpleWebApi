using AutoMapper;
using MediatR;
using WebApiTest6._0.Application.Interfaces;

namespace WebApiTest6._0.Application.Features.Student.Commands
{
    public class CreateStudentCommand
    {
        public class Request : IRequest<Guid>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Handler : IRequestHandler<Request, Guid>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(Request request, CancellationToken cancellationToken)
            {
                var student = _mapper.Map<Domain.Entities.Student>(request);
                await unitOfWork.StudentRepository.CreateAsync(student);
                return student.Id;
            }
        }
    }
}
