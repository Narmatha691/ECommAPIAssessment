using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommAPIAssessment.Entities
{

    [Table("Users")]
    public class User
    {
        [Key]
        public string? UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set;}
        [Required]
        public string? Password { get; set;}
        [Required]
        public string? Role { get; set;}

    }
}
