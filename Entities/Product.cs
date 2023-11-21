using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommAPIAssessment.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public User Supplier { get; set; }

    }
}
