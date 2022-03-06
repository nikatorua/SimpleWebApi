namespace WebApiTest6._0.Domain.Basics
{
    public abstract class AuditableEntity : BaseEntity
    {
        public virtual int Version { get; set; } = 0;

        public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public virtual Guid? CreatedBy { get; set; }

        public virtual DateTime? DateUpdated { get; set; }
        public virtual Guid? UpdatedBy { get; set; }

        public virtual DateTime? DateDeleted { get; set; }
        public virtual Guid? DeletedBy { get; set; }
    }
}
