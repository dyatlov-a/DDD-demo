using System.ComponentModel.DataAnnotations;

namespace DDD.Services.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
