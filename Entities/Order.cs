using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommAPIAssessment.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
