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
            var head = new Employee("Иванов Иван", "Капитан галеры");
            head.AddEmployee(new Employee("Петров Петр", "Гребец"));
            head.AddEmployee(new Employee("Сергей Сергеевич", "Гребец"));
            context.Set<Employee>().Add(head);
            context.SaveChanges();
        }
    }
}
