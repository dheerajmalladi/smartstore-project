using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class BillingAddress
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string fullname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        // Paymnent Model

        [Required]
        [Display(Name = "Name on Card")]
        public string NameonCard { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit card Number")]
        public string Creditcard { get; set; }

        [Required]
        [Display(Name = "Exp Month")]
        public string expmonth { get; set; }

        [Required]
        [Display(Name = "Exp Year")]
        public int expyear { get; set; }

        [Required]
        public int CVV { get; set; }

    }
}
