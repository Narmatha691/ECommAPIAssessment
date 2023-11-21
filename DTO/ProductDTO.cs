using ECommAPIAssessment.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommAPIAssessment.DTO
{
    public class ProductDTO
    {
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public string? SupplierId { get; set; }
    }
}
