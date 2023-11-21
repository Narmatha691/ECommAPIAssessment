using System.ComponentModel.DataAnnotations;

namespace ECommAPIAssessment.DTO
{
    public class OrderwithIdDTO
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public string? UserId { get; set; }
    }
}
