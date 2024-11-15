using System.ComponentModel.DataAnnotations;

namespace RiskTrack.DTOs{
    public class ProviderCreateDTO {
        [Required]
        public string TradeName { get; set; }
        [Required]
        public string TID{ get; set; }
        [Required]
        public string PhoneNumber{ get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string Website{ get; set; }
        [Required]
        public string Address{ get; set; }
        [Required]
        public string Country{ get; set; }
        [Required]
        public decimal AnualRevenue { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}