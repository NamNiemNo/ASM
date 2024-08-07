using System.ComponentModel.DataAnnotations;

namespace PH47185.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
