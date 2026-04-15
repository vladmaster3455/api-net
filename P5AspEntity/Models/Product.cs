using System.ComponentModel.DataAnnotations;

namespace P5AspEntity.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public double Price { get; set; }
    }
}