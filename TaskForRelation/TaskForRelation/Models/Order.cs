using System.ComponentModel.DataAnnotations;

namespace TaskForRelation.Models
{
    public class Order
    {

        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Range(0, 10)]
        public int Count { get; set; }
        public Employee Employee { get; set; }
        public Product Product { get; set; }

    }
}
