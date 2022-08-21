using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class users
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? fname { get; set; }

        [Required]
        public string? lname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="date of birth")]
        public string? dob { get; set; }
        public string? gender { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int phno { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? emailid { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string? password { get; set; }

        [Required]
        public int user_category { get; set; }

    }
}
