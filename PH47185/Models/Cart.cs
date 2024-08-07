using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PH47185.Models
{
    public class Cart
    {
        [Key]
        public int IdCart { get; set; }
        [ForeignKey("Product")]
        public int IdProduct {  get; set; }
        public string ProductName { get; set; }
        public int? Amount { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

    }
}
