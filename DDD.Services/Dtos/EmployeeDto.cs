using System;
using System.Collections.Generic;

namespace DDD.Services.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
