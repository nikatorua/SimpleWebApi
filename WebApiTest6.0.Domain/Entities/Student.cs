using WebApiTest6._0.Domain.Basics;

namespace WebApiTest6._0.Domain.Entities
{
    public class Student : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}