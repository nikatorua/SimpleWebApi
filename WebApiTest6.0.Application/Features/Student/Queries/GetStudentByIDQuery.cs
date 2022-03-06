using MediatR;
using WebApiTest6._0.Application.Interfaces;

namespace WebApiTest6._0.Application.Features.Student.Queries
{
    public class GetStudentByIDQuery
    {
        public record Request(Guid StudentID) : IRequest<Domain.Entities.Student>;

        public class Handler : IRequestHandler<Request, Domain.Entities.Student>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Domain.Entities.Student> Handle(Request request, CancellationToken cancellationToken)
            {
                var student = await unitOfWork.StudentRepository.ReadAsync(request.StudentID);
                return await Task.FromResult(student);
            }
        }
    }
}
