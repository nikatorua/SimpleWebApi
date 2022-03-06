using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApiTest6._0.Domain.Basics;
using WebApiTest6._0.Domain.Entities;

namespace WebApiTest6._0.Persistance
{
    internal class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                this.Audition(entry);

            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                this.Audition(entry);

            return base.SaveChanges();
        }

        private void Audition(EntityEntry<AuditableEntity> entry)
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.Version++;

                    entry.Entity.DateUpdated = DateTime.UtcNow;

                    entry.Property(nameof(AuditableEntity.CreatedBy)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.DateCreated)).IsModified = false;

                    entry.Property(nameof(AuditableEntity.DeletedBy)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.DateDeleted)).IsModified = false;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;

                    entry.Entity.DateDeleted = DateTime.UtcNow;
                    break;
            };
        }
    }
}
