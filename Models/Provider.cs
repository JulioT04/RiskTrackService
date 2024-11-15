using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RiskTrack.Models {
    public class Provider {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string  TradeName { get; set; }
        [Required]
        public string TID { get; set; }
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
        public decimal AnualRevenue{ get; set; }
        public DateTime LastEditedDate{ get; set; }
        
        [Required]
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}