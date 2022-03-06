using WebApiTest6._0.Application.Interfaces;
using WebApiTest6._0.Application.Interfaces.Repositories;
using WebApiTest6._0.Persistance.Implementations.Repositories;

namespace WebApiTest6._0.Persistance.Implementations
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context) => _context = context;
        private IStudentRepository studentRepository;
        public IStudentRepository StudentRepository => studentRepository ??= new StudentRepository(_context);
        public void Dispose() => _context.Dispose();
    }
}
