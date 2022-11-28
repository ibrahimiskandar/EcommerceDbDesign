using System.ComponentModel.DataAnnotations;

namespace TaskForRelation.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int Count { get; set; }
        [Required]
        public double CostPrice { get; set; }
        [Required]
        public double SalePrice { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
