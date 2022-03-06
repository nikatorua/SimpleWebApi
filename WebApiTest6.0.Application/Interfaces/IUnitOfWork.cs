using WebApiTest6._0.Application.Interfaces.Repositories;

namespace WebApiTest6._0.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }
    }
}
