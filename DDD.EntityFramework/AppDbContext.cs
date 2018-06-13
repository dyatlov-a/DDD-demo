using System.Data.Entity;
using DDD.Domain.EmployeeAggregate;
using DDD.Domain.IssueAggregate;

namespace DDD.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Issue>()
                .Property(e => e.RowVersion)
                .IsRowVersion();
            modelBuilder.ComplexType<InitiatorInfo>();

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Employee>()
                .Property(e => e.RowVersion)
                .IsRowVersion();
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Head)
                .HasForeignKey(e => e.HeadId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
