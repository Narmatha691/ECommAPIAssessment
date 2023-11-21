using System.ComponentModel.DataAnnotations;

namespace ECommAPIAssessment.DTO
{
    public class OrderDTO
    {
        public int ProductId { get; set; }
        public string? UserId { get; set; }
    }
}
