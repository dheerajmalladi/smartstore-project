using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Cart
    {
        [Key]
        public int cartid { get; set; }
        public int id { get; set; }

        public int p_id { get; set; }

        public string? p_name { get; set; }

        public string? p_image_url { get; set; }
        public int quantity { get; set; }
        public int p_price { get; set; }
        public int totalprice { get; set; }



    }
}
