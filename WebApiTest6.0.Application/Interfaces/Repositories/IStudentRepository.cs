using WebApiTest6._0.Domain.Entities;

namespace WebApiTest6._0.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IRepository<Guid, Student>
    {
    }
}
