using System.ComponentModel.DataAnnotations;

namespace TaskForRelation.DTOs
{
    public class OrderDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int ProductId { get; set; }

    }
}
