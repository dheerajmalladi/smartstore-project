using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Login
    {
        [Required]
        public string emailid { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string password { get; set; }
    }
}
