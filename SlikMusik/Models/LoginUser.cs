using System.ComponentModel.DataAnnotations;

namespace SlikMusik.Models
{
    public class LoginUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}