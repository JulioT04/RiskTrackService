using System.ComponentModel.DataAnnotations;

namespace RiskTrack.DTOs{
    public class UserCreateDTO {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}