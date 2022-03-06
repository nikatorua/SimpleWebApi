using WebApiTest6._0.Application.Interfaces.Repositories;
using WebApiTest6._0.Domain.Entities;

namespace WebApiTest6._0.Persistance.Implementations.Repositories
{
    internal class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context)
        {
        }
    }
}
