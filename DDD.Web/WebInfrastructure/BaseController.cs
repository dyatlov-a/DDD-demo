using System;
using System.Web.Http;
using DDD.Domain.EmployeeAggregate;

namespace DDD.Web.WebInfrastructure
{
    public abstract class BaseController : ApiController
    {
        protected IUser CurrentUser()
        {
            return new User("UserName", "Position");
        }
    }

    public class User : IUser
    {
        public string Name { get; private set; }
        public string Position { get; private set; }

        public User(string name, string position)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (String.IsNullOrWhiteSpace(position))
                throw new ArgumentNullException(nameof(position));

            Name = name;
            Position = position;
        }
    }
}