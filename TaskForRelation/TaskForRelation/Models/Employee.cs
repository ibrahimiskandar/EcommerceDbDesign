using System.ComponentModel.DataAnnotations;

namespace TaskForRelation.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
