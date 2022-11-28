using System.ComponentModel.DataAnnotations;

namespace TaskForRelation.DTOs
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Count { get; set; }
        [Required]
        public double CostPrice { get; set; }
        [Required]
        public double SalePrice { get; set; }
    
}
}
