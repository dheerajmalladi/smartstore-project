using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class orders
    {
        [Required]
        [Key]
        public int orderId { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public int totalprice { get; set; }
    }
}
