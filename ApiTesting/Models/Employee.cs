using System.ComponentModel.DataAnnotations;

namespace ApiTesting.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
