using System.ComponentModel.DataAnnotations;

namespace RiskTrack.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

         public ICollection<Provider> Providers { get; set; } 
    }
}
