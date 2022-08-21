using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "Product_Id")]
        public int p_id { get; set; }

        [Required]
        [Display(Name ="product_Name")]
        public string? p_name { get; set; }

        [Required]
        [Display(Name ="product_Type")]
        public string? p_type { get; set; }

        [Required]
        [Display(Name = "product_Brand")]
        public string? p_brand { get; set; }

        [Display(Name ="product_Description")]
        public string? p_description { get; set; }

        [Required]
        [Display(Name ="product_size")]
        public string? p_size { get; set; }

        [Required]
        [Display(Name ="product_price")]
        public int? p_price { get; set; }

        [Required]
        [Display(Name = "product_quantity")]
        public int? p_quantity { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "product_image")]
        public String? p_image_url { get; set; }

    }
}
