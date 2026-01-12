using System.ComponentModel.DataAnnotations;

namespace NetworkingDemo.API.DTOs
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}