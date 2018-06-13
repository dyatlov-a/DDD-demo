using System.Data.Entity.Migrations;
using DDD.Domain.EmployeeAggregate;

namespace DDD.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {
            var head = new Employee("������ ����", "������� ������");
            head.AddEmployee(new Employee("������ ����", "������"));
            head.AddEmployee(new Employee("������ ���������", "������"));
            context.Set<Employee>().Add(head);
            context.SaveChanges();
        }
    }
}
