using System.ComponentModel.DataAnnotations;
namespace CartNest.Core.DTOs
{
    public class AdminDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

