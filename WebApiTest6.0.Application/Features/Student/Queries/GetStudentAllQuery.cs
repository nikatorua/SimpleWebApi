using MediatR;
using WebApiTest6._0.Application.Interfaces;

namespace WebApiTest6._0.Application.Features.Student.Queries
{
    public class GetStudentAllQuery
    {
        public record Request() : IRequest<IEnumerable<Domain.Entities.Student>>;
        public class Handler : IRequestHandler<Request, IEnumerable<Domain.Entities.Student>>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Domain.Entities.Student>> Handle(Request request, CancellationToken cancellationToken)
            {
                var students = await unitOfWork.StudentRepository.ReadAsync();
                return await Task.FromResult(students);
            }
        }
    }
}
